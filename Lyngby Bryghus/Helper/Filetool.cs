using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lyngby_Bryghus.Helpers
{
    public class FileTool
    {
        public string LoadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path, System.Text.Encoding.UTF8);
            }
            else
            {
                return null;
            }
        }
        public bool SaveJson(string value, string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.ReadAllText(path, System.Text.Encoding.UTF8);
                    StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
                    sw.Write(value);
                    sw.Close();
                    return true;
                }catch{
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public string Fileupload(HttpPostedFileBase file, string name, string outputPath, string[] allowTypes)
        {
            if (allowTypes == null)
                allowTypes = new string[] { "*" };
            string filename = Path.GetFileName(file.FileName);
            string extention = Path.GetExtension(file.FileName).Substring(1).ToLower();

            if (allowTypes.Contains("*") || allowTypes.Contains(extention))
            {
                String newName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + name + "." + extention;
                file.SaveAs(outputPath + newName);
                return newName;
            }
            else
            {
                return null;
            }
        }
        public bool deleteFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}