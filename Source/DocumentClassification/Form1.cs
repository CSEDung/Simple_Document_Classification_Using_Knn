using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace DocumentClassification
{
    public partial class MainForm : Form
    {
        private string[] SubFolders;
        private List<string> Dictionary;
        private bool kNN;
        private bool Train;
        private int Classes;
        bool KeepAll;
        public MainForm()
        {
            InitializeComponent();
            kNN = true;
            Train = true;
            KeepAll = false;
        }

        private void vntokenizer()
        {
            Process proc = null;
            try
            {
                string s = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string batDir = string.Format(s);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = "_vntokenizer.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
                //MessageBox.Show("VnTokenizer executed !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        private void btn_browInputFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txt_folderPath.Text = fbd.SelectedPath;
                    SubFolders = Directory.GetDirectories(fbd.SelectedPath);
                    lb_subFolderFound.Text = SubFolders.Length.ToString();
                    Classes = SubFolders.Length;
                    txt_k.Text = (SubFolders.Length * 2+1).ToString();
                }
            }
        }

        private void createBAT(string path, string path_o)
        {
            string wri = "cd vntokenizer \n vnTokenizer.bat -i " + path +" -o "+ path_o;
            File.WriteAllText(".\\_vntokenizer.bat", wri, Encoding.ASCII);
        }

        private void btn_vntokenizer_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(".\\Temp"))
            {
                Directory.CreateDirectory(".\\Temp");
            }
            else
            {
                Directory.Delete(".\\Temp", true);
                Directory.CreateDirectory(".\\Temp");
            }
            foreach (string fol in SubFolders)
            {        
                int i = fol.Length-1;
                while (fol[i] != '\\') i--;
                string name = fol.Substring(i + 1, fol.Length - i - 1);
                if (!Directory.Exists(".\\Temp\\" + name))
                    Directory.CreateDirectory(".\\Temp\\" + name);
                createBAT(fol, "..\\Temp\\" + name);
                vntokenizer();
            }
            MessageBox.Show("VnTokenizer done !!");
        }

        static string getClassName(string dir)
        {
            int i;
            for (i = dir.Length - 1; i > 0; i--)
            {
                if (dir[i] == '\\') break;
            }
            return dir.Substring(i + 1);
        }

        static bool checkCharecter(char ch)
        {
            string s = "1234567890~!@#$%^&*()+<>?,.';:[]{}=\"‘’–-“”…//\\\n\0";
            foreach (char c in s)
            {
                if (c == ch) return false;
            }
            return true;
        }

        static string removeStopWord(string inline, string outline, string[] stopword)
        {
            bool equa = false;
            string word = "";
            for (int i = 0; i < inline.Length; i++) // check all text file
            {
                if (!checkCharecter(inline[i])) continue; // 2. Remove some characters
                if (inline[i] != ' ')
                {
                    word += inline[i];
                }
                else if (word.Length > 1)
                {
                    foreach (string sw in stopword)
                    {
                        if (word.CompareTo(sw) == 0) //compare to stopword list
                        {
                            equa = true;
                        }
                    }
                    if (!equa) // word is not stopword
                    {
                        outline += word;
                        outline += " ";
                    } // set defause to continue
                    equa = false;
                    word = "";
                }
                else
                {
                    word = "";
                }
            }
            return outline;
        }

        static FileInfo[] getFiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

            /*foreach (FileInfo file in Files)
            {
                Console.WriteLine(file);
            }*/

            return Files;
        }

        static string removeStopWords(string dir, string input, string[] StopWord)
        {
            string output = "";
            string[] text = File.ReadAllLines(dir + "\\" + input);
            //File.WriteAllLines(".\\input.txt", text, Encoding.Unicode); Kiem tra chuoi doc vao
            foreach (string textline in text)
            {

                //string line = textline; // None Lower
                string line = textline.ToLower(); // 1. To Lower
                output = removeStopWord(line, output, StopWord);
            }
            input = input.Remove(input.Length - 3);
            File.WriteAllText(".\\out\\" + input + "rsw", output, Encoding.UTF8);
            return output;
        }

        private List<string> reduceBag(List<string> bag, List<string> word)
        {
            List<int> data = new List<int>();
            for (int i = 0; i < bag.Count; i++)
            {
                data.Add(0);
            }

            // Check dictionary
            foreach (string wrd in word)
            {
                for (int i = 0; i < bag.Count; i++)
                {
                    if (wrd.CompareTo(bag.ElementAt(i)) == 0)
                    {
                        data[i] += 1;
                    }
                }
            }

            //Sort dictionanry each file
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (data[i] < data[j])
                    {
                        int a = data[i];
                        data[i] = data[j];
                        data[j] = a;
                        string s = bag[i];
                        bag[i] = bag[j];
                        bag[j] = s;
                    }
                }
            }
            // Remove some work
            int top = 0;
            Int32.TryParse(txt_top.Text, out top);
            if (bag.Count > top && !KeepAll)
            {
                bag.RemoveRange(top, bag.Count - top);
            }
            return bag;
        }

        private List<string> runBagOfWord(string input, string name)
        {
            List<string> bows = new List<string>();
            List<string> words = new List<string>();
            bool equa = false;
            string word = "";
            // find out dictionary and word each file
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    word += input[i];
                }
                else
                {
                    words.Add(word);
                    foreach (string bow in bows)
                    {
                        if (word.CompareTo(bow) == 0)
                        {
                            equa = true;
                        }
                    }
                    if (!equa)
                    {
                        bows.Add(word);
                    }
                    equa = false;
                    word = "";

                }
            }
            bows = reduceBag(bows, words);
            name = name.Remove(name.Length - 3);
            File.WriteAllLines(".\\out\\" + name + "bow", bows, Encoding.UTF8);
            File.WriteAllLines(".\\out\\" + name + "wrd", words, Encoding.UTF8);
            return bows;
        }

        static List<string> checkDictionary(List<string> dics, List<string> checks)
        {
            bool equa = false;
            // only add new word to dictionary
            foreach (string check in checks)
            {
                foreach (string dic in dics)
                {
                    if (dic.CompareTo(check) == 0)
                    {
                        equa = true;
                    }
                }
                // new word
                if (!equa)
                {
                    dics.Add(check); // add new word
                }
                equa = false;
            }
            return dics;
        }

        private List<string> convertDataSetWithBOWs(string type, string bowfile, List<string> dictionary, List<string> output)
        {
            string attri = "";
            List<int> data = new List<int>();
            // create a list same size with dictionary
            for (int i = 0; i < dictionary.Count; i++)
            {
                data.Add(0);
            }
            // each file, read all word and check in dictionary
            bowfile = bowfile.Remove(bowfile.Length - 3);
            bowfile += "wrd";
            string[] lines = File.ReadAllLines(".\\out\\" + bowfile);
            foreach (string line in lines)
            {
                for (int i = 0; i < dictionary.Count; i++)
                {
                    if (dictionary.ElementAt(i).CompareTo(line) == 0)
                    {
                        data[i] += 1;
                    }
                }
            }
            if (kNN)
            {
                foreach (int i in data)
                {
                    attri += i;
                    attri += ".0,"; // Defause
                }
                attri += type;
                output.Add(attri);
            }else
            {
                int index = 0;
                foreach (int i in data)
                {
                    type += " " + index + ":"+i; // For SVM
                    index += 1;
                }
                attri += type;
                output.Add(attri);
            }
            return output;
        }

        private void Doc2Words()
        {
            if (!Directory.Exists(".\\Temp"))
            {
                Directory.CreateDirectory(".\\Temp");
            }  
            if (!Directory.Exists(".\\out"))
            {
                Directory.CreateDirectory(".\\out");
            }else
            {
                Directory.Delete(".\\out",true);
                Directory.CreateDirectory(".\\out");
            }               
            if (!Directory.Exists(".\\Dictionary"))
                Directory.CreateDirectory(".\\Dictionary");

            string stopword = @".\\data\vnstopword.txt";
            string[] StopWord = File.ReadAllLines(stopword);

            string Result = "";
            List<string> Bows = new List<string>();
            Dictionary = new List<string>();

            string[] dirs = Directory.GetDirectories(".\\Temp");

            foreach (string dir in dirs)
            {
                FileInfo[] files = getFiles(dir);
                foreach (FileInfo file in files)
                {
                    string dirname = getClassName(dir);
                    //Console.WriteLine(">>>> Processing Class: " + dirname + " <<o>> on file: " + file);

                    Result = removeStopWords(dir, file.Name, StopWord);
                    Bows = runBagOfWord(Result, file.Name);
                }
            }
        }

        private void btn_bagOfWord_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(".\\Temp"))
            {
                Directory.CreateDirectory(".\\Temp");
            }
            if (!Directory.Exists(".\\out"))
            {
                Directory.CreateDirectory(".\\out");
            }
            else
            {
                Directory.Delete(".\\out",true);
                Directory.CreateDirectory(".\\out");
            }
            if (!Directory.Exists(".\\Dictionary"))
                Directory.CreateDirectory(".\\Dictionary");

            string stopword = @".\\data\vnstopword.txt";
            string[] StopWord = File.ReadAllLines(stopword);
            //File.WriteAllLines(".\\data\\test.txt", StopWord, Encoding.Unicode);

            string Result = "";
            List<string> Bows = new List<string>();
            Dictionary = new List<string>();

            string[] dirs = Directory.GetDirectories(".\\Temp");
            if (rbt_TrainFile.Checked)
            {
                foreach (string dir in dirs)
                {
                    FileInfo[] files = getFiles(dir);
                    foreach (FileInfo file in files)
                    {
                        string dirname = getClassName(dir);
                        Result = removeStopWords(dir, file.Name, StopWord);
                        Bows = runBagOfWord(Result, file.Name);
                        Dictionary = checkDictionary(Dictionary, Bows);
                    }
                }
                if (kNN)
                {
                    File.WriteAllLines(".\\Dictionary\\Bows.knn.dic", Dictionary, Encoding.UTF8);
                }
                else
                {
                    File.WriteAllLines(".\\Dictionary\\Bows.svm.dic", Dictionary, Encoding.UTF8);
                }
            }
            else
            {
                foreach (string dir in dirs)
                {
                    FileInfo[] files = getFiles(dir);
                    foreach (FileInfo file in files)
                    {
                        string dirname = getClassName(dir);
                        Result = removeStopWords(dir, file.Name, StopWord);
                        Bows = runBagOfWord(Result, file.Name);
                    }
                }
            }
            
            
            MessageBox.Show("Bag of Words done !!");
        }
        private void convertDataset()
        {
            if (Directory.Exists(".\\Dictionary"))
            {
                string[] dirs = Directory.GetDirectories(".\\Temp");
                Dictionary = new List<string>();
                string[] lines = File.ReadAllLines(".\\Dictionary\\Bows.knn.dic");
                foreach (string line in lines)
                {
                    Dictionary.Add(line);
                }

                List<string> DataSet = new List<string>();
                foreach (string dir in dirs)
                {
                    FileInfo[] files = getFiles(dir);
                    foreach (FileInfo file in files)
                    {
                        string dirname = getClassName(dir);
                        DataSet = convertDataSetWithBOWs(dirname, file.Name, Dictionary, DataSet);
                    }
                }
                File.WriteAllLines(".\\Dictionary\\Dataset.knn.test", DataSet, Encoding.ASCII);
            }else
            {
                MessageBox.Show("Không tìm thấy từ điển");
            }
            
        }

        private void btn_convertDataset_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(".\\Dictionary"))
            {
                string[] dirs = Directory.GetDirectories(".\\Temp");
                Dictionary = new List<string>();
                string[] lines;
                if (kNN)
                {
                    lines = File.ReadAllLines(".\\Dictionary\\Bows.knn.dic");
                }
                else
                {
                    lines = File.ReadAllLines(".\\Dictionary\\Bows.svm.dic");
                }
                foreach (string line in lines)
                {
                    Dictionary.Add(line);
                }
                List<string> DataSet = new List<string>();
                foreach (string dir in dirs)
                {
                    FileInfo[] files = getFiles(dir);
                    foreach (FileInfo file in files)
                    {
                        string dirname = getClassName(dir);

                        DataSet = convertDataSetWithBOWs(dirname, file.Name, Dictionary, DataSet);
                    }
                }

                if (kNN)
                {
                    // Lọc bỏ các dòng dữ liệu trùng nhau.
                    for (int i = 0; i < DataSet.Count - 1; i++)
                    {
                        string s1 = DataSet.ElementAt(i);
                        int index = s1.Length - 1;
                        while (s1.ElementAt(index) != ',')
                        {
                            index--;
                        }
                        index--;
                        s1 = s1.Remove(index);

                        for (int j = i + 1; j < DataSet.Count; j++)
                        {
                            string s2 = DataSet.ElementAt(j);
                            index = s2.Length - 1;
                            while (s2.ElementAt(index) != ',')
                            {
                                index--;
                            }
                            index--;
                            s2 = s2.Remove(index);
                            if (s1.CompareTo(s2) == 0)
                            {
                                DataSet.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                    // Ket thuc lọc dữ liệu
                    if (rbt_TrainFile.Checked)
                    {
                        File.WriteAllLines(".\\Dictionary\\Dataset.knn.train", DataSet, Encoding.ASCII);
                    }
                    else
                    {
                        File.WriteAllLines(".\\Dictionary\\Dataset.knn.test", DataSet, Encoding.ASCII);
                    }

                }
                else
                {
                    if (rbt_TrainFile.Checked)
                    {
                        File.WriteAllLines(".\\Dictionary\\Dataset.svm.train", DataSet, Encoding.ASCII);
                    }
                    else
                    {
                        File.WriteAllLines(".\\Dictionary\\Dataset.svm.test", DataSet, Encoding.ASCII);
                    }

                }
                MessageBox.Show("Converted !!");
            }else
            {
                MessageBox.Show("Không tìm thấy từ điển");
            }
            
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            kNN = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            kNN = false;
        }

        private string get_Name_Class(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        return "Cộng đồng";
                    }
                case 2:
                    {
                        return "Du lịch";
                    }
                case 3:
                    {
                        return "Gia đình";
                    }
                case 4:
                    {
                        return "Giáo dục";
                    }
                case 5:
                    {
                        return "Giải trí";
                    }
                case 6:
                    {
                        return "Khoa học";
                    }
                case 7:
                    {
                        return "Kinh doanh";
                    }
                case 8:
                    {
                        return "Pháp luật";
                    }
                case 9:
                    {
                        return "Số hóa";
                    }
                case 10:
                    {
                        return "Sức khỏe";
                    }
                case 11:
                    {
                        return "Tâm sự";
                    }
                case 12:
                    {
                        return "Thế giới";
                    }
                case 13:
                    {
                        return "Thể thao";
                    }
                case 14:
                    {
                        return "Tâm sự";
                    }
                case 15:
                    {
                        return "Xe";
                    }
            }
            return "Unknown";
        }

        private void btn_knn_Click(object sender, EventArgs e)
        {
            Train = false;
            txt_text.Text = "Testing is running...";
            // Before
            if (!File.Exists(".\\Dictionary\\Dataset.knn.test"))
            {
                SubFolders = Directory.GetDirectories(txt_folderPath.Text);
                btn_vntokenizer_Click(sender, e);
                Doc2Words();
                convertDataset();
            }           
            // Reading model file
            int k = 0;
            Int32.TryParse(txt_k.Text, out k);
            if (k % 2 == 0)
            {
                k++;
            }
            Knn kNN_predict = Knn.initialiseKNN(k, ".\\Dictionary\\Dataset.knn.train", true);

            // Reading test file
            string[] tests = File.ReadAllLines(".\\Dictionary\\Dataset.knn.test");
            List<string> Result = new List<string>();
            List<string> Label = new List<string>();
            List<double> Classify = new List<double>();
            foreach (string test in tests)
            {
                string s = "";
                Classify.Clear();
                for (int i = 0; i < test.Length; i++)
                {
                    if (test[i] != ',')
                    {
                        s += test[i];
                    }
                    else
                    {
                        double value = 0.0;
                        Double.TryParse(s, out value);
                        Classify.Add(value);
                        s = "";
                    }
                }
                Label.Add(s);
                string result = kNN_predict.Classify(Classify);
                Result.Add(result);
            }

            List<string> CMD = new List<string>();
            string cmd = "";
            List<int> T = new List<int>();
            List<int> F = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                T.Add(0);
                F.Add(0);
            }
            for (int i = 0; i < Label.Count; i++)
            {
                if (Label.ElementAt(i) == Result.ElementAt(i))
                {
                    Int32.TryParse(Label.ElementAt(i), out k);
                    T[k]++;
                }
                else
                {
                    Int32.TryParse(Label.ElementAt(i), out k);
                    F[k]++;
                }
            }

            for (int i = 1; i < 16; i++)
            {
                if (F[i] + T[i] != 0)
                {
                    cmd = "Class: " + get_Name_Class(i) + " :: T = " + T[i].ToString() + " <> F = " + F[i].ToString() + "      ";
                    cmd += "Acc: " + ((double)T[i] * 100 / (F[i] + T[i])).ToString() + " %";
                    CMD.Add(cmd);
                }
                
            }
            cmd = "Test Accuracy: " + ((double)T.Sum() * 100 / (T.Sum() + F.Sum())).ToString() + " %";
            CMD.Add(cmd);
            txt_text.Text = String.Join(Environment.NewLine, CMD);
            

            // After 
            Train = true;
            MessageBox.Show("Done !");
        }

        private void btn_predict_Click(object sender, EventArgs e)
        {
            if (txt_text.Text != "")
            {
                
                List<string> CMD = new List<string>();
                string s1 = "=== ===Step 0: Văn bản gốc === ===";
                CMD.Add(s1);
                CMD.Add(" ");

                txt_out.Text = "Predicting... ";
                int k = 0;
                Int32.TryParse(txt_k.Text, out k);
                string txt = txt_text.Text;
                txt_text.Text = "Predicting... ";
                CMD.Add(txt);
                string s2 = "=== ===Step 1: Xử lý VnTokenizer === ===";
                CMD.Add(" "); CMD.Add(" ");
                CMD.Add(s2);
                CMD.Add(" ");

                File.WriteAllText(".\\temp.txt", txt, Encoding.UTF8);
                createBAT("..\\temp.txt", "..\\VnT.txt");
                vntokenizer();
                string stopword = @".\\data\vnstopword.txt";
                string[] StopWord = File.ReadAllLines(stopword);
                string output = "";
                string[] text = File.ReadAllLines(".\\VnT.txt");
                foreach (string textline in text)
                {
                    CMD.Add(textline);
                    string line = textline.ToLower(); // 1. To Lower
                    output = removeStopWord(line, output, StopWord);
                }

                string s3 = "=== ===Step 2: Xóa Stop Word === ===";
                CMD.Add(" "); CMD.Add(" ");
                CMD.Add(s3);
                CMD.Add(" ");

                List<string> words = new List<string>();
                string word = "";
                // find out dictionary and word each file
                for (int i = 0; i < output.Length; i++)
                {
                    if (output[i] != ' ')
                    {
                        word += output[i];
                    }
                    else
                    {
                        words.Add(word);
                        word = "";

                    }
                }

                string vb_word = "";
                string vb_code = "";

                if (rb_knn.Checked)
                {
                    List<int> data = new List<int>();
                    string[] dictionary = File.ReadAllLines(".\\Dictionary\\Bows.knn.dic");
                    // create a list same size with dictionary
                    for (int i = 0; i < dictionary.Length; i++)
                    {
                        data.Add(0);
                    }
                    // each file, read all word and check in dictionary

                    foreach (string line in words)
                    {
                        vb_word += line + " ";
                        for (int i = 0; i < dictionary.Length; i++)
                        {
                            if (dictionary.ElementAt(i).CompareTo(line) == 0)
                            {
                                data[i] += 1;
                            }
                        }
                    }

                    List<double> Classify = new List<double>();
                    foreach (int i in data)
                    {
                        Classify.Add((double)i * 1.0);
                        vb_code += i.ToString() + " ";
                    }
                    if (k % 2 == 0) k--;
                    Knn kNN_predict = Knn.initialiseKNN(k, ".\\Dictionary\\Dataset.knn.train", true);
                    string s = kNN_predict.Classify(Classify);
                    int predict = Int32.Parse(s);
                    txt_out.Text = "Predict class is: " + get_Name_Class(predict);
                }
                else
                {
                    List<int> data = new List<int>();
                    string[] dictionary = File.ReadAllLines(".\\Dictionary\\Bows.svm.dic");
                    // create a list same size with dictionary
                    for (int i = 0; i < dictionary.Length; i++)
                    {
                        data.Add(0);
                    }
                    // each file, read all word and check in dictionary

                    foreach (string line in words)
                    {
                        vb_word += line + " ";
                        for (int i = 0; i < dictionary.Length; i++)
                        {
                            if (dictionary.ElementAt(i).CompareTo(line) == 0)
                            {
                                data[i] += 1;
                            }
                        }
                    }

                    string Classifi = "0";
                    int index = 0;
                    foreach (int i in data)
                    {
                        Classifi += " "+index.ToString()+":"+i.ToString();
                        index++;
                        vb_code += i.ToString() + " ";
                    }
                    File.WriteAllText(".\\temp.txt", Classifi, Encoding.ASCII);
                    string wri = "cd svm \n svm_predict.exe ..\\temp.txt Model Output.txt";
                    File.WriteAllText(".\\svm_test.bat", wri, Encoding.ASCII);
                    Process proc = null;
                    try
                    {
                        string s = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                        string batDir = string.Format(s);
                        proc = new Process();
                        proc.StartInfo.WorkingDirectory = batDir;
                        proc.StartInfo.FileName = "svm_test.bat";
                        proc.StartInfo.CreateNoWindow = false;
                        proc.Start();
                        proc.WaitForExit();
                        proc.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace.ToString());
                    }

                    string[] result = File.ReadAllLines(".\\svm\\Output.txt");

                    int predict = Int32.Parse(result[0]);
                    txt_out.Text = "Predict class is: " + get_Name_Class(predict);
                }

                CMD.Add(vb_word);
                string s4 = "=== ===Step 4: Mã hóa bằng từ điển BOWS === ===";
                CMD.Add(" "); CMD.Add(" ");
                CMD.Add(s4);
                CMD.Add(" ");
                CMD.Add(vb_code);
                
                txt_text.Text = String.Join(Environment.NewLine, CMD);
            }
            else
            {
                MessageBox.Show("Text box dose not emtry !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @".\\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string text = File.ReadAllText(theDialog.FileName);
                    txt_text.Text = text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void rbt_keepAll_Click(object sender, EventArgs e)
        {
            KeepAll = true;
        }

        private void rdb_top_Click(object sender, EventArgs e)
        {
            KeepAll = false;
        }

        private void btn_svm_Click(object sender, EventArgs e)
        {
            string wri = "cd svm \n svm_predict.exe ..\\Dictionary\\Dataset.svm.test Model Output.txt";
            File.WriteAllText(".\\svm_test.bat", wri, Encoding.ASCII);
            Process proc = null;
            try
            {
                string s = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string batDir = string.Format(s);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = "svm_test.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }

            List<string> Label = new List<string>();
            string[] tests = File.ReadAllLines(".\\Dictionary\\Dataset.svm.test");           
            string[] result = File.ReadAllLines(".\\svm\\Output.txt");
            foreach (string test in tests){
                string s = "";
                int i = 0;
                while (test[i] != ' ')
                {
                    s += test[i];
                    i++;
                }
                Label.Add(s);
            }
            List<string> CMD = new List<string>();
            string cmd = "";
            List<int> T = new List<int>();
            List<int> F = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                T.Add(0);
                F.Add(0);
            }
            int k = 0;
            for (int i = 0; i < Label.Count; i++)
            {
                Int32.TryParse(Label.ElementAt(i), out k);
                if (k.ToString() == result[i])
                {
                    T[k]++;
                }
                else
                {
                    F[k]++;
                }
            }
            for (int i = 1; i < 16; i++)
            {
                if(F[i] + T[i] != 0)
                {
                    cmd = "Class: " + get_Name_Class(i) + " :: T = " + T[i].ToString() + " <> F = " + F[i].ToString() + "      ";
                    cmd += "Acc: " + ((double)T[i] * 100 / (F[i] + T[i])).ToString() + " %";
                    CMD.Add(cmd);
                }
                
            }
            cmd = "Test Accuracy: " + ((double)T.Sum() * 100 / (T.Sum() + F.Sum())).ToString() + " %";
            CMD.Add(cmd);
            txt_text.Text = "";
            txt_text.Text = String.Join(Environment.NewLine, CMD);
        }
    }
}