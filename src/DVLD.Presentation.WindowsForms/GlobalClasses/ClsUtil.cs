using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.WindowsForms.GlobalClasses
{
    internal class ClsUtil
    {
        public static string GenarateGUID()
        {
            Guid NewGuid = Guid.NewGuid();

            return NewGuid.ToString();
        }
    

        public static string  ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo fileInfo = new FileInfo(sourceFile);
            string GUID = GenarateGUID();

             return GUID + fileInfo.Extension;
        }
        public static bool CreateFolderIfDoseNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {

                try
                {
                   
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex )
                {
                    MessageBox.Show(@"Error Creating Folder : " + ex.Message);
                    return false;
                }
            }
            return true;
        }


        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestnationFolder = @"C:\DVLD_People_Images\";

            if (!CreateFolderIfDoseNotExist(DestnationFolder))
            {
                return false;
            }

            string DestnationFile = DestnationFolder +ReplaceFileNameWithGUID(SourceFile);

            try
            {

                File.Copy(SourceFile, DestnationFile, true);

            }
            catch (IOException IOE)
            {
                MessageBox.Show(IOE.Message , "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            SourceFile = DestnationFile;

            return true;
            

        }
    
    }
}
