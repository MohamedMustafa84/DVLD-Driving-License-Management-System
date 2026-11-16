using DVLD.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.GlobalClasses
{
    public class ClsGlobal
    {
        public static ClsUser CurrentUser = new ClsUser();


        public static bool SaveUserNameAndPassword(string UserName, string Password)
        {

            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\data.txt";

                if (UserName == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                string DataToSave = UserName + "#//#" + Password;

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.Write(DataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving User Credational :" + ex.Message);
                return false;
            }
        }

        public static bool GetStoredGredential(ref string UserName,ref string Password)
        {
            try
            {

                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath= CurrentDirectory + "\\data.txt";

                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);

                            string[] Result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            UserName = Result[0];
                            Password = Result[1];
                        }
                            return true;
                    }
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("an error accurred : "+ex.Message);
                return false;
            }
        }
    }
}
