using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using IOOperations.Components;

namespace IOOperations
{
public class JsonRW
    {
    public JsonRW ( string fileName)
    { 
        this.mFileName = fileName;
    }

    string mFileName;
    public string FileName
    {
        get { return mFileName; }
        set { mFileName = value; }
    }
      
    public bool  Write(string fileName,Components.DataSerie2D ds2)
        {
            bool result = false;
            if (object.Equals(ds2, null)) { return false; }
           try
            {
               using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate))
               {
                   using (StreamWriter sw = new StreamWriter (fs))
                   {
                       string jsonTxt = JsonConvert.SerializeObject(ds2);
                       sw.Write(jsonTxt );
                       sw.Flush();
                       sw.Close();
                       result = true;
                   }

                   fs.Close();
               }
              
            }
            catch (Exception ex)
            { throw ex; }
            //---------------------------------
            return result ;
        }
      
    public DataSerie2D Read_DS2 (string fileName)
    {
        DataSerie2D ds2 = new DataSerie2D();

        return ds2;
    }

}
}
