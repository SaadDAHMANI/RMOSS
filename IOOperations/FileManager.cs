/*
 * Created by SharpDevelop.
 * User: Saad
 * Date: 01/11/2015
 * Time: 12:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using IOOperations.Components;
using System.Xml;

namespace IOOperations
{
	/// <summary>
	/// Description of FileManager.
	/// </summary>
	 public class FileManager
    {
          public FileManager(ref string filePath)
            {
                this.FileName = filePath;

            }
          string FileName = string.Empty;

        public bool Write(ref DataSerie3D ds3)
            {
                bool result = false;
                if (object.Equals(ds3, null)) { return result; }
                try
                {

                    using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
                    {
                        using (BinaryWriter bnrWriter = new BinaryWriter(fs))
                        {
                            bnrWriter.Write(ds3.Name);
                            bnrWriter.Write(ds3.Description);
                            bnrWriter.Write(ds3.X_Title);
                            bnrWriter.Write(ds3.Y_Title);
                            bnrWriter.Write(ds3.Z_Title);

                            if (object .Equals (ds3.Data ,null ))
                            {
                                bnrWriter.Write(0); 
                            }
                            else
                            {
                                bnrWriter.Write(ds3.Data.Count);
                            foreach (DataItem3D di3 in ds3.Data)
                            {
                                bnrWriter.Write(di3.Title);
                                bnrWriter.Write(di3.X_Value);
                                bnrWriter.Write(di3.Y_Value);
                                bnrWriter.Write(di3.Z_Value);
                            }
                            }
                            bnrWriter.Flush();
                            bnrWriter.Close();
                            result = true;
                        }
                       
                        //fs.Flush();
                        //fs.Close();
                    }
                }
                catch (Exception ex)
                { throw ex; }
                return result;
            }

		public bool Write(ref DataSerie1D ds1)
		{
			bool result = false;
			if (object.Equals(ds1, null)) { return result; }
			try
			{

				using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
				{
					using (BinaryWriter bnrWriter = new BinaryWriter(fs))
					{
						bnrWriter.Write(ds1.Name);
						bnrWriter.Write(ds1.Description);
						bnrWriter.Write(ds1.X_Title);
					

						if (object.Equals(ds1.Data, null))
						{
							bnrWriter.Write(0);
						}
						else
						{
							bnrWriter.Write(ds1.Data.Count);

							foreach (DataItem1D di2 in ds1.Data)
							{
								bnrWriter.Write(di2.Title);
								bnrWriter.Write(di2.X_Value);
							}
						}


						bnrWriter.Flush();

						result = true;
					}
					//fs.Flush();
					//fs.Close();
				}

			}
			catch (Exception ex)
			{ throw ex; }
			return result;
		}
		public bool Write(ref DataSerie2D ds2)
            {
                bool result = false;
                if (object.Equals(ds2, null)) { return result; }
                try
                {

                    using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
                    {
                    using (BinaryWriter bnrWriter = new BinaryWriter(fs))
                    {
                    bnrWriter.Write(ds2.Name);
                    bnrWriter.Write(ds2.Description);
                    bnrWriter.Write(ds2.X_Title);
                    bnrWriter.Write(ds2.Y_Title);

                    if (object.Equals(ds2.Data, null))
                    {
                        bnrWriter.Write(0);
                    }
                    else
                    { 
                    bnrWriter.Write(ds2.Data.Count);

                    foreach (DataItem2D di2 in ds2.Data)
                    {
                        bnrWriter.Write(di2.Title);
                        bnrWriter.Write(di2.X_Value);
                        bnrWriter.Write(di2.Y_Value);
                    }
                    }
                    

                    bnrWriter.Flush();
                  
                    result = true;
                    }
                    //fs.Flush();
                    //fs.Close();
                    }
                    
                }
                catch (Exception ex)
                { throw ex; }
                return result;
            }

            public bool Write(List<DataSerie2D> d2Series)
            {
                bool result = false;
                if (object.Equals(d2Series, null)) { return false; }
                try
                {
                    using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
                    {

                        using (BinaryWriter bnrWriter = new BinaryWriter(fs))
                        {
                            if (object.Equals(d2Series, null))
                            {
                                bnrWriter.Write(0);
                            }
                            else
                            {
                                int sCount = d2Series.Count;
                                bnrWriter.Write(sCount);
                                if (sCount > 0)
                                {
                                    foreach (DataSerie2D ds2 in d2Series)
                                    {
                                        bnrWriter.Write(ds2.Name);
                                        bnrWriter.Write(ds2.Description);
                                        bnrWriter.Write(ds2.Title);
                                        bnrWriter.Write(ds2.X_Title);
                                        bnrWriter.Write(ds2.Y_Title);
                                        if (object.Equals(ds2.Data, null))
                                        { bnrWriter.Write(0); }
                                        else
                                        {
                                            sCount = ds2.Data.Count;
                                            bnrWriter.Write(sCount);
                                            if (sCount > 0)
                                            {
                                                foreach (DataItem2D ditm2 in ds2.Data)
                                                {
                                                    bnrWriter.Write(ditm2.Title);
                                                    bnrWriter.Write(ditm2.X_Value);
                                                    bnrWriter.Write(ditm2.Y_Value);
                                                }
                                            }
                                        }
                                    }

                                }
                            }

                            bnrWriter.Flush();
                            bnrWriter.Close();
                            result = true;
                        }
                        fs.Flush();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                { throw ex; }
                return result;
            }


            public bool Write(List<DataSerie5D> d5Series)
            {
                bool result = false;
                if (object.Equals(d5Series, null)) { return false; } 
                try
                {

                    using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
                    {
                        using (BinaryWriter bnrWriter = new BinaryWriter(fs))
                        {
                            if (object.Equals(d5Series, null))
                            {
                                bnrWriter.Write(0);
                            }
                            else
                            {
                                int sCount = d5Series.Count;
                                bnrWriter.Write(sCount);
                                if (sCount > 0)
                                {
                                    foreach (DataSerie5D ds5 in d5Series)
                                    {
                                        bnrWriter.Write(ds5.Name);
                                        bnrWriter.Write(ds5.Description);
                                        bnrWriter.Write(ds5.Title);
                                        bnrWriter.Write(ds5.A_Title);
                                        bnrWriter.Write(ds5.B_Title);
                                        bnrWriter.Write(ds5.C_Title);
                                        bnrWriter.Write(ds5.D_Title);
                                        bnrWriter.Write(ds5.E_Title);

                                        if (object.Equals(ds5.Data, null))
                                        { bnrWriter.Write(0); }
                                        else
                                        {
                                            sCount = ds5.Data.Count;
                                            bnrWriter.Write(sCount);
                                            if (sCount > 0)
                                            {
                                                foreach (DataItem5D ditm2 in ds5.Data)
                                                {
                                                    bnrWriter.Write(ditm2.Title);
                                                    bnrWriter.Write(ditm2.A_Value);
                                                    bnrWriter.Write(ditm2.B_Value);
                                                    bnrWriter.Write(ditm2.C_Value);
                                                    bnrWriter.Write(ditm2.D_Value);
                                                    bnrWriter.Write(ditm2.E_Value);
                                                }
                                            }
                                        }
                                    }

                                }
                            }

                            bnrWriter.Flush();
                            bnrWriter.Close();
                            result = true;
                        }
                        fs.Flush();
                     
                    }
                }
                catch (Exception ex)
                { throw ex; }
                return result;
            }

            public bool Write(ref RmosProject ioProjet)
            {
                bool result = false;
                if (object.Equals(ioProjet, null)) { return false; }
                try
                {
                    using (FileStream fs = File.Open(FileName, FileMode.OpenOrCreate))
                    {
                        using (BinaryWriter bnryWriter = new BinaryWriter(fs))
                        {
                            bnryWriter.Write(ioProjet.Name);
                            bnryWriter.Write(ioProjet.Description);
                            bnryWriter.Write(ioProjet.ReservoirFileName);
                            bnryWriter.Write(ioProjet.InflowSeriesFileName);
                            bnryWriter.Write(ioProjet.ObjectifFunctionFileName);
                                                        
                            bnryWriter.Flush();
                            bnryWriter.Close();
                            result = true;
                        }

                    }
                }
                catch (Exception ex)
                { throw ex;}
                return result;
 
            }

            public bool WriteXML(ref RmosProject ioProject)
            {
                bool result = false;
             try
             { 
                 //if (File.Exists (ioProject .ProjectFileName )==false)
                 //{
                 //    File.Create(ioProject.ProjectFileName);
                    
                 //}
                 using (XmlWriter writer = XmlWriter.Create(ioProject.ProjectFileName ))
                 {
                     writer.WriteStartElement("RMOS-Project");

                     writer.WriteElementString("InflowSeries", ioProject.InflowSeriesFileName);
                     writer.WriteElementString("DemandSeries", ioProject.DemandSeriesFileName);
                     writer.WriteElementString("HVCurve",ioProject .HVCurveFileName);
                     writer.WriteElementString("HSCurve", ioProject.HSCurveFileName);
                     writer.WriteElementString("EvaporationCurve", ioProject.EvaporationCurveFileName);

                     writer.WriteEndElement();
                     writer.Flush();
                     writer.Close();
                 }
                result = true;
                 }
             catch (Exception ex )
             {
                 result = false;
                 throw ex; 
             }
                return result;
            }

            public RmosProject ReadXml()
         {
             if (object.Equals(this.FileName, null)) { return null; }
             if (File.Exists(this.FileName) == false) { return null;}

             RmosProject ioProject = new RmosProject();
             using (XmlReader reader = XmlReader.Create(this.FileName ))
             {
                 while (reader.Read())
                 {
                     if (reader.IsStartElement())
                     {
                         switch (reader.Name.ToString())
                         {
                             case "InflowSeries":
                                 ioProject.InflowSeriesFileName = reader.ReadString();
                                 break;

                             case "DemandSeries":
                                 ioProject.DemandSeriesFileName = reader.ReadString();
                                 break;

                             case "HVCurve":
                                 ioProject.HVCurveFileName = reader.ReadString();
                                 break;

                             case "HSCurve":
                                 ioProject.HSCurveFileName  = reader.ReadString();
                                 break;

                             case "EvaporationCurve":
                                ioProject.EvaporationCurveFileName  = reader.ReadString();
                                 break;
                         }

                     }


                 }


             }
             return ioProject;

         }

            public RmosProject ReadXml(string fileName)
         {
             if (object.Equals(fileName, null)) { return null; }
             if (File.Exists(fileName) == false) { return null; }

             RmosProject ioProject = new RmosProject();
             using (XmlReader reader = XmlReader.Create(fileName))
             {
                 while (reader.Read())
                 {
                     if (reader.IsStartElement())
                     {
                        switch (reader.Name.ToString())
                        {
                            case "InflowSeries":
                                ioProject.InflowSeriesFileName = reader.ReadString();
                                break;

                            case "DemandSeries":
                                ioProject.DemandSeriesFileName = reader.ReadString();
                                break;

                            case "HVCurve":
                                ioProject.HVCurveFileName = reader.ReadString();
                                break;

                            case "HSCurve":
                                ioProject.HSCurveFileName = reader.ReadString();
                                break;

                            case "EvaporationCurve":
                                ioProject.EvaporationCurveFileName = reader.ReadString();
                                break;
                        }

                    }

                  
                 }


             }
             return ioProject;

         }
            
            public RmosProject Read_ProjectInfos()
            {
                RmosProject ioProject = null;
                if (FileName == string.Empty) { return null; }
                if (File.Exists(FileName))
                {
                    try
                    {
                        using (FileStream fs = File.Open(FileName, FileMode.Open))
                        {
                            using (BinaryReader bnryReader = new BinaryReader(fs))
                            {
                                ioProject = new RmosProject();

                                ioProject.Name  = bnryReader.ReadString();
                                ioProject.Description =  bnryReader.ReadString();
                                ioProject.ReservoirFileName = bnryReader.ReadString();
                                ioProject.InflowSeriesFileName  = bnryReader.ReadString();
                                ioProject.ObjectifFunctionFileName = bnryReader.ReadString();
                                bnryReader.Close();
                            }

                            fs.Flush();
                            fs.Close();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                }

                return ioProject;
            }
            public RmosProject Read_ProjectInfos( string fileName)
            {
                RmosProject ioProject = null;
                if (fileName == string.Empty) { return null; }
                if (File.Exists(fileName))
                {
                    try
                    {
                        using (FileStream fs = File.Open(fileName, FileMode.Open))
                        {
                            using (BinaryReader bnryReader = new BinaryReader(fs))
                            {
                                ioProject = new RmosProject();

                                ioProject.Name = bnryReader.ReadString();
                                ioProject.Description = bnryReader.ReadString();
                                ioProject.ReservoirFileName = bnryReader.ReadString();
                                ioProject.InflowSeriesFileName = bnryReader.ReadString();
                                ioProject.ObjectifFunctionFileName = bnryReader.ReadString();
                                bnryReader.Close();
                            }

                            fs.Flush();
                            fs.Close();
                        }
                    }
                    catch (Exception ex)
                    { throw ex; }
                }

                return ioProject;
            }

		public DataSerie1D Read_DS1()
		{
			DataSerie1D ds = new DataSerie1D();
			try
			{

				if (FileName == string.Empty)
				{ return null; }

				if (File.Exists(this.FileName))
				{
					FileStream fs = File.Open(this.FileName, FileMode.Open);
					BinaryReader bnryReader = new BinaryReader(fs);
					int dCount = 0;
					ds.Name = bnryReader.ReadString();
					ds.Description = bnryReader.ReadString();
					ds.X_Title = bnryReader.ReadString();
					
					dCount = bnryReader.ReadInt32();

					if (dCount > 0)
					{
						double x, y;
						string z;
						for (int i = 0; i < dCount; i++)
						{
							z = bnryReader.ReadString();
							x = bnryReader.ReadDouble();
							ds.Add(z, x);
						}
					}
					bnryReader.Close();
					fs.Close();
				}
				else
				{
					throw new FileNotFoundException("File not found", this.FileName);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;

		}
		public DataSerie1D Read_DS1(string fileName)
		{
			DataSerie1D ds = new DataSerie1D();
			try
			{

				if (fileName == string.Empty)
				{ return null; }

				if (File.Exists(fileName))
				{
					FileStream fs = File.Open(fileName, FileMode.Open);
					BinaryReader bnryReader = new BinaryReader(fs);
					int dCount = 0;
					ds.Name = bnryReader.ReadString();
					ds.Description = bnryReader.ReadString();
					ds.X_Title = bnryReader.ReadString();
					
					dCount = bnryReader.ReadInt32();

					if (dCount > 0)
					{
						double x, y;
						string z;
						for (int i = 0; i < dCount; i++)
						{
							z = bnryReader.ReadString();
							x = bnryReader.ReadDouble();
							
							ds.Add(z, x);
						}
					}
					bnryReader.Close();
					fs.Close();
				}
				else
				{
					throw new FileNotFoundException("File not found", fileName);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;

		}

		public DataSerie2D Read_DS2()
            {
                DataSerie2D ds2 = new DataSerie2D();
                try
                {

                    if (FileName == string.Empty)
                    { return null; }

                    if (File.Exists(this.FileName))
                    {
                        FileStream fs = File.Open(this.FileName, FileMode.Open);
                        BinaryReader bnryReader = new BinaryReader(fs);
                        int dCount = 0;
                        ds2.Name = bnryReader.ReadString();
                        ds2.Description = bnryReader.ReadString();
                        ds2.X_Title = bnryReader.ReadString();
                        ds2.Y_Title = bnryReader.ReadString();

                        dCount = bnryReader.ReadInt32();

                        if (dCount > 0)
                        {
                            double x, y;
                            string z;
                            for (int i = 0; i < dCount; i++)
                            {
                                z = bnryReader.ReadString();
                                x = bnryReader.ReadDouble();
                                y = bnryReader.ReadDouble();
                                ds2.Add(z, x, y);
                            }
                            }
                        bnryReader.Close();
                        fs.Close();
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", this.FileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds2;

            }
            public DataSerie2D Read_DS2( string fileName)
            {
                DataSerie2D ds2 = new DataSerie2D();
                try
                {

                    if (fileName == string.Empty)
                    { return null; }

                    if (File.Exists(fileName))
                    {
                        FileStream fs = File.Open(fileName, FileMode.Open);
                        BinaryReader bnryReader = new BinaryReader(fs);
                        int dCount = 0;
                        ds2.Name = bnryReader.ReadString();
                        ds2.Description = bnryReader.ReadString();
                        ds2.X_Title = bnryReader.ReadString();
                        ds2.Y_Title = bnryReader.ReadString();

                        dCount = bnryReader.ReadInt32();

                        if (dCount > 0)
                        {
                            double x, y;
                            string z;
                            for (int i = 0; i < dCount; i++)
                            {
                                z = bnryReader.ReadString();
                                x = bnryReader.ReadDouble();
                                y = bnryReader.ReadDouble();
                                ds2.Add(z, x, y);
                            }
                        }
                        bnryReader.Close();
                        fs.Close();
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", fileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds2;

            }

            public DataSerie3D Read_DS3()
            {
                DataSerie3D ds3 = null;
                try
                {
                    if (FileName == string.Empty)
                    { return null; }

                    if (File.Exists(this.FileName))
                    {

                        using (FileStream fs = File.Open(this.FileName, FileMode.Open))
                        {
                            ds3 = new DataSerie3D();
                            BinaryReader bnryReader = new BinaryReader(fs);

                            int dCount = 0;
                            ds3.Name = bnryReader.ReadString();
                            ds3.Description = bnryReader.ReadString();
                            ds3.X_Title = bnryReader.ReadString();
                            ds3.Y_Title = bnryReader.ReadString();
                            ds3.Z_Title = bnryReader.ReadString();
                            dCount = bnryReader.ReadInt32();

                            if (dCount > 0)
                            {

                                string title;
                                double x, y, z;
                                for (int i = 0; i < dCount; i++)
                                {
                                    title = bnryReader.ReadString();
                                    x = bnryReader.ReadDouble();
                                    y = bnryReader.ReadDouble();
                                    z = bnryReader.ReadDouble();
                                    ds3.Add(title, x, y, z);
                                }

                            }

                            bnryReader.Close();
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", this.FileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds3;

            }
            public DataSerie3D Read_DS3(string fileName)
            {
                DataSerie3D ds3 = null;
                try
                {
                    if (fileName == string.Empty)
                    { return null; }

                    if (File.Exists(fileName))
                    {

                        using (FileStream fs = File.Open(fileName, FileMode.Open))
                        {
                            ds3 = new DataSerie3D();
                            BinaryReader bnryReader = new BinaryReader(fs);

                            int dCount = 0;
                            ds3.Name = bnryReader.ReadString();
                            ds3.Description = bnryReader.ReadString();
                            ds3.X_Title = bnryReader.ReadString();
                            ds3.Y_Title = bnryReader.ReadString();
                            ds3.Z_Title = bnryReader.ReadString();
                            dCount = bnryReader.ReadInt32();

                            if (dCount > 0)
                            {

                                string title;
                                double x, y, z;
                                for (int i = 0; i < dCount; i++)
                                {
                                    title = bnryReader.ReadString();
                                    x = bnryReader.ReadDouble();
                                    y = bnryReader.ReadDouble();
                                    z = bnryReader.ReadDouble();
                                    ds3.Add(title, x, y, z);
                                }

                            }

                            bnryReader.Close();
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", fileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds3;

            }

            public List<DataSerie2D> Read_DS2List()
            {
                List<DataSerie2D> d2Series = new List<DataSerie2D>();
                try
                {
                    if (FileName == string.Empty)
                    { return null; }

                    if (File.Exists(this.FileName))
                    {
                        using (FileStream fs = File.Open(this.FileName, FileMode.Open))
                        {

                            using (BinaryReader bnryReader = new BinaryReader(fs))
                            {
                                int dCount = 0;
                                dCount = bnryReader.ReadInt32();
                                if (dCount > 0)
                                {
                                    DataSerie2D ds2;
                                    int itmCount = 0;
                                    for (int i = 0; i < dCount; i++)
                                    {
                                        ds2 = new DataSerie2D();
                                        ds2.Name = bnryReader.ReadString();
                                        ds2.Description = bnryReader.ReadString();
                                        ds2.Title = bnryReader.ReadString();
                                        ds2.X_Title = bnryReader.ReadString();
                                        ds2.Y_Title = bnryReader.ReadString();

                                        itmCount = bnryReader.ReadInt32();
                                        if (itmCount > 0)
                                        {
                                            string title;
                                            double xx, yy;
                                            for (int j = 0; j < itmCount; j++)
                                            {

                                                title = bnryReader.ReadString();
                                                xx = bnryReader.ReadDouble();
                                                yy = bnryReader.ReadDouble();
                                                ds2.Add(title, xx, yy);
                                            }
                                        }
                                        d2Series.Add(ds2);
                                    }
                                }
                                               
                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", this.FileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return d2Series;
            }
            public List<DataSerie2D> Read_DS2List( string fileName)
            {
                List<DataSerie2D> d2Series = new List<DataSerie2D>();
                try
                {
                    if (fileName == string.Empty)
                    { return null; }

                    if (File.Exists(fileName))
                    {
                        using (FileStream fs = File.Open(fileName, FileMode.Open))
                        {

                            using (BinaryReader bnryReader = new BinaryReader(fs))
                            {
                                int dCount = 0;
                                dCount = bnryReader.ReadInt32();
                                if (dCount > 0)
                                {
                                    DataSerie2D ds2;
                                    int itmCount = 0;
                                    for (int i = 0; i < dCount; i++)
                                    {
                                        ds2 = new DataSerie2D();
                                        ds2.Name = bnryReader.ReadString();
                                        ds2.Description = bnryReader.ReadString();
                                        ds2.Title = bnryReader.ReadString();
                                        ds2.X_Title = bnryReader.ReadString();
                                        ds2.Y_Title = bnryReader.ReadString();

                                        itmCount = bnryReader.ReadInt32();
                                        if (itmCount > 0)
                                        {
                                            string title;
                                            double xx, yy;
                                            for (int j = 0; j < itmCount; j++)
                                            {

                                                title = bnryReader.ReadString();
                                                xx = bnryReader.ReadDouble();
                                                yy = bnryReader.ReadDouble();
                                                ds2.Add(title, xx, yy);
                                            }
                                        }
                                        d2Series.Add(ds2);
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", fileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return d2Series;
            }

            public List<DataSerie5D> Read_DS5List()
            {
                List<DataSerie5D> d5Series = new List<DataSerie5D>();
                try
                {
                    if (FileName == string.Empty)
                    { return null; }

                    if (File.Exists(this.FileName))
                    {
                        using (FileStream fs = File.Open(this.FileName, FileMode.Open))
                        {

                            using (BinaryReader bnryReader = new BinaryReader(fs))
                            {
                                int dCount = 0;
                                dCount = bnryReader.ReadInt32();
                                if (dCount > 0)
                                {
                                    DataSerie5D ds5;
                                    int itmCount = 0;
                                    for (int i = 0; i < dCount; i++)
                                    {
                                        ds5 = new DataSerie5D();
                                        ds5.Name = bnryReader.ReadString();
                                        ds5.Description = bnryReader.ReadString();
                                        ds5.Title = bnryReader.ReadString();
                                        ds5.A_Title = bnryReader.ReadString();
                                        ds5.B_Title = bnryReader.ReadString();
                                        ds5.C_Title = bnryReader.ReadString();
                                        ds5.D_Title = bnryReader.ReadString();
                                        ds5.E_Title = bnryReader.ReadString();

                                        itmCount = bnryReader.ReadInt32();
                                        if (itmCount > 0)
                                        {
                                            string title;
                                            double aa, bb, cc,dd,ee;
                                            for (int j = 0; j < itmCount; j++)
                                            {

                                                title = bnryReader.ReadString();
                                                aa = bnryReader.ReadDouble();
                                                bb = bnryReader.ReadDouble();
                                                cc = bnryReader.ReadDouble();
                                                dd = bnryReader.ReadDouble();
                                                ee = bnryReader.ReadDouble();
                                                ds5.Add(title, aa, bb,cc,dd,ee);
                                            }
                                        }
                                        d5Series.Add(ds5);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", this.FileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return d5Series;
            }
            public List<DataSerie5D> Read_DS5List( string fileName)
            {
                List<DataSerie5D> d5Series = new List<DataSerie5D>();
                try
                {
                    if (fileName == string.Empty)
                    { return null; }

                    if (File.Exists(fileName))
                    {
                        using (FileStream fs = File.Open(fileName, FileMode.Open))
                        {

                            using (BinaryReader bnryReader = new BinaryReader(fs))
                            {
                                int dCount = 0;
                                dCount = bnryReader.ReadInt32();
                                if (dCount > 0)
                                {
                                    DataSerie5D ds5;
                                    int itmCount = 0;
                                    for (int i = 0; i < dCount; i++)
                                    {
                                        ds5 = new DataSerie5D();
                                        ds5.Name = bnryReader.ReadString();
                                        ds5.Description = bnryReader.ReadString();
                                        ds5.Title = bnryReader.ReadString();
                                        ds5.A_Title = bnryReader.ReadString();
                                        ds5.B_Title = bnryReader.ReadString();
                                        ds5.C_Title = bnryReader.ReadString();
                                        ds5.D_Title = bnryReader.ReadString();
                                        ds5.E_Title = bnryReader.ReadString();

                                        itmCount = bnryReader.ReadInt32();
                                        if (itmCount > 0)
                                        {
                                            string title;
                                            double aa, bb, cc, dd, ee;
                                            for (int j = 0; j < itmCount; j++)
                                            {

                                                title = bnryReader.ReadString();
                                                aa = bnryReader.ReadDouble();
                                                bb = bnryReader.ReadDouble();
                                                cc = bnryReader.ReadDouble();
                                                dd = bnryReader.ReadDouble();
                                                ee = bnryReader.ReadDouble();
                                                ds5.Add(title, aa, bb, cc, dd, ee);
                                            }
                                        }
                                        d5Series.Add(ds5);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found", this.FileName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return d5Series;
            }

        }
}
