using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOOperations.Components;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace IOOperations
{
    public class IOProject
    {
        public string Name ="";
        public string Description="";
        DateTime CreateDate;
        public string FileName;


        public IOReservoir Reservoir=null;
           
        public bool Save(string filePath, IOFileFormatEnum format)
        {
            bool result = false;
           if (format== IOFileFormatEnum.XML)
            {
               result = WriteXML(filePath);
                return result;
            }
           else
            { result = false;
              throw new Exception("Not supported yet."); }
         }

        bool WriteXML(string filepath)
        {
           bool result = false;
            try
            {
                if (object.Equals(Reservoir, null) == false)
                {
                    using (FileStream fs = File.Open(filepath, FileMode.OpenOrCreate))
                    { 

                    XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                    XElement root = new XElement("RMOSProject");
                    root.Add(new XAttribute("Version", "1.0"),
                        new XAttribute("FileVersion", "1.0"),
                        new XAttribute("ProjectName", this.Name),
                        new XAttribute("Description",this.Description), 
                        new XAttribute("CreateDate", DateTime.Now.ToString()));

                    //----------------------------------------------

                    XElement xreservoir = new XElement("Reservoir");
                    xreservoir.Add(
                        new XAttribute("Name", Reservoir.Name),
                        new XAttribute("Description", Reservoir.Description),
                        new XAttribute("MinCapacity", Reservoir.MinCapacity),
                        new XAttribute("MaxCapacity", Reservoir.MaxCapacity),
                        new XAttribute("MinRelease", Reservoir.MinRelease),
                        new XAttribute("MaxRelease", Reservoir.MaxRelease));

                    //-------------------------------------------------------------------------------
                    XElement xHS = new XElement("Curve_Elevation_Area");
                    if (object.Equals(Reservoir.Elevation_Area, null) == false)
                    {
                        DataSerie2D ds = Reservoir.Elevation_Area;

                        xHS.Add(new XAttribute("Name", ds.Name),
                            new XAttribute("Description", ds.Description),
                            new XAttribute("Title", ds.Title),
                            new XAttribute("X_Title", ds.X_Title),
                            new XAttribute("Y_Title", ds.Y_Title),
                            new XAttribute("Count", ds.Count));

                        XElement xd = null;
                        foreach (DataItem2D d in ds.Data)
                        {
                            xd = new XElement("Title", d.Title);
                            xd.Add(new XAttribute("x", d.X_Value), new XAttribute("y", d.Y_Value));
                            xHS.Add(xd);
                        }
                    }
                    else { xHS.Add(new XElement("Name", "N/a"), new XElement("Count"), 0); }

                    //-------------------------------------------------------------------------------
                    XElement xHV = new XElement("Curve_Elevation_Volume");
                    if (object.Equals(Reservoir.Elevation_Volume, null) == false)
                    {
                        DataSerie2D ds = Reservoir.Elevation_Volume;

                        xHV.Add(new XAttribute("Name", ds.Name),
                            new XAttribute("Description", ds.Description),
                            new XAttribute("Title", ds.Title),
                            new XAttribute("X_Title", ds.X_Title),
                            new XAttribute("Y_Title", ds.Y_Title),
                            new XAttribute("Count", ds.Count));

                        XElement xd = null;
                        foreach (DataItem2D d in ds.Data)
                        {
                            xd = new XElement("Title", d.Title);
                            xd.Add(new XAttribute("x", d.X_Value), new XAttribute("y", d.Y_Value));
                            xHV.Add(xd);
                        }
                    }
                    else { xHV.Add(new XElement("Name", "N/a"), new XElement("Count"), 0); }

                    //-------------------------------------------------------------------------------

                    XElement xEvapo = new XElement("Evaporation");
                    if (object.Equals(Reservoir.Evaporation, null) == false)
                    {
                        DataSerie2D ds = Reservoir.Evaporation;

                        xEvapo.Add(new XAttribute("Name", ds.Name),
                            new XAttribute("Description", ds.Description),
                            new XAttribute("Title", ds.Title),
                            new XAttribute("X_Title", ds.X_Title),
                            new XAttribute("Y_Title", ds.Y_Title),
                            new XAttribute("Count", ds.Count));

                        XElement xd = null;
                        foreach (DataItem2D d in ds.Data)
                        {
                            xd = new XElement("Title", d.Title);
                            xd.Add(new XAttribute("x", d.X_Value), new XAttribute("y", d.Y_Value));
                            xEvapo.Add(xd);
                        }
                    } else { xEvapo.Add(new XElement("Name", "N/a"), new XElement("Count"), 0); }

                    //----------------------------------------------------------------------------------

                    XElement xInfilt = new XElement("Infiltration");
                    if (object.Equals(Reservoir.Infiltration, null) == false)
                    {
                        DataSerie2D ds = Reservoir.Infiltration;

                        xInfilt.Add(new XAttribute("Name", ds.Name),
                            new XAttribute("Description", ds.Description),
                            new XAttribute("Title", ds.Title),
                            new XAttribute("X_Title", ds.X_Title),
                            new XAttribute("Y_Title", ds.Y_Title),
                            new XAttribute("Count", ds.Count));

                        XElement xd = null;
                        foreach (DataItem2D d in ds.Data)
                        {
                            xd = new XElement("Title", d.Title);
                            xd.Add(new XAttribute("x", d.X_Value), new XAttribute("y", d.Y_Value));
                            xInfilt.Add(xd);
                        }
                    }
                    else { xInfilt.Add(new XAttribute("Name", "n/a"), new XAttribute("Count", 0)); }

                    //----------------------------------------------------------------------------------
                    //-------------Inflow:----------------------------------------
                    XElement xinflow = new XElement("Inflow");

                    if (object.Equals(Reservoir.Inflow, null) == false)
                    {
                        DataSerie1D ds = Reservoir.Inflow;

                        xinflow.Add(new XAttribute("Name", ds.Name),
                            new XAttribute("Description", ds.Description),
                            new XAttribute("Title", ds.Title),
                            new XAttribute("X_Title", ds.X_Title),
                            new XAttribute("Count", ds.Count));

                        XElement xq = null;
                        foreach (DataItem1D q in ds.Data)
                        {
                            xq = new XElement("Title", q.Title);
                            xq.Add(new XAttribute("x", q.X_Value));
                            xinflow.Add(xq);
                        }

                    }
                    else { xinflow.Add(new XAttribute("Name", "N/a"), new XAttribute("Count", 0)); }

                    XElement xDstrm = new XElement("Downstream");
                    if (object.Equals(Reservoir.Downstream, null) == false)
                    {
                        DataSerie1D ds = Reservoir.Downstream;
                        xDstrm.Add(new XAttribute("Name", ds.Name),
                        new XAttribute("Description", ds.Description),
                            new XAttribute("Title", ds.Title),
                            new XAttribute("X_Title", ds.X_Title),
                            new XAttribute("Count", ds.Count));

                        XElement xd = null;
                        foreach (DataItem1D d in ds.Data)
                        {
                            xd = new XElement("Title", d.Title);
                            xd.Add(new XAttribute("x", d.X_Value));
                            xDstrm.Add(xd);
                        }
                    }
                    else { xDstrm.Add(new XElement("Name", "N/a"), new XElement("Count"), 0); }

                    //-----------------------------------------------------------------------------
                    xreservoir.Add(xHS);
                    xreservoir.Add(xHV);
                    xreservoir.Add(xEvapo);
                    xreservoir.Add(xInfilt);
                    xreservoir.Add(xinflow);
                    xreservoir.Add(xDstrm);
                    root.Add(xreservoir);
                    //----------------------------------------------
                    xdoc.Add(root);
                    xdoc.Save(fs);
                    fs.Flush();
                    fs.Close();
                      
                    result = true;
                }
            }
            }
            catch (Exception ex)
            { throw ex; }
            this.FileName = filepath;
            return result;
        }

      public void ReadXML(string filepath)
        {
            try
            {
              XDocument xdoc = XDocument.Load(filepath);
              var prj = xdoc.Root;
                string version = (string)prj.Attribute("Version");
                string fileVersion = (string)prj.Attribute("FileVersion");
                this.Name  = (string)prj.Attribute("ProjectName");
                this.Description = (string)prj.Attribute("Description"); 
                this.CreateDate = (DateTime)prj.Attribute("CreateDate");

                if (fileVersion =="1.0")
                {
                    this.Reservoir = new IOReservoir();
                    var resrvr = prj.Element("Reservoir");
                    
                    this.Reservoir.Name  = (string)resrvr.Attribute("Name");
                    this.Reservoir.Description = (string)resrvr.Attribute("Description");
                    this.Reservoir.MinCapacity = (double)resrvr.Attribute("MinCapacity");
                    this.Reservoir.MaxCapacity = (double)resrvr.Attribute("MaxCapacity");
                    this.Reservoir.MinRelease = (double)resrvr.Attribute("MinRelease");
                    this.Reservoir.MaxRelease = (double)resrvr.Attribute("MaxRelease");

                    //-- Elevation_Area-------------------------------------------------------
                    DataSerie2D ds2 = new DataSerie2D();
                    var xhs = resrvr.Element("Curve_Elevation_Area");
                    int count = (int)xhs.Attribute("Count");
                    if (count>0)
                    {
                        ds2.Name = (string)xhs.Attribute("Name");
                        ds2.Description = (string)xhs.Attribute("Description");
                        ds2.Title = (string)xhs.Attribute("Title");
                        ds2.X_Title = (string)xhs.Attribute("X_Title");
                        ds2.Y_Title = (string)xhs.Attribute("Y_Title");

                        // Data :
                        var items = from dt in xhs.Elements()
                                    select new
                                    {
                                        T = (string)dt.Attribute("Title"),
                                        x = (double)dt.Attribute("x"),
                                        y = (double)dt.Attribute("y")
                                    };
                        foreach(var dt in items)
                        {
                            ds2.Add(dt.T, dt.x, dt.y);
                        }
                    }
                    this.Reservoir.Elevation_Area = ds2;


                    //-- Curve_Elevation_Volume : -------------------------------------------------------
                    ds2 = new DataSerie2D();
                    var xvs = resrvr.Element("Curve_Elevation_Volume");
                    count = (int)xvs.Attribute("Count");
                    if (count > 0)
                    {
                        ds2.Name = (string)xvs.Attribute("Name");
                        ds2.Description = (string)xvs.Attribute("Description");
                        ds2.Title = (string)xvs.Attribute("Title");
                        ds2.X_Title = (string)xvs.Attribute("X_Title");
                        ds2.Y_Title = (string)xvs.Attribute("Y_Title");

                        // Data :
                        var items = from dt in xvs.Elements()
                                    select new
                                    {
                                        T = (string)dt.Attribute("Title"),
                                        x = (double)dt.Attribute("x"),
                                        y = (double)dt.Attribute("y")
                                    };
                        foreach (var dt in items)
                        {
                            ds2.Add(dt.T, dt.x, dt.y);
                        }
                    }
                    this.Reservoir.Elevation_Volume = ds2;

                   //---------Evaporation :
                    ds2 = new DataSerie2D();
                    var xev = resrvr.Element("Evaporation");
                    count = (int)xev.Attribute("Count");
                    if (count > 0)
                    {
                        ds2.Name = (string)xev.Attribute("Name");
                        ds2.Description = (string)xev.Attribute("Description");
                        ds2.Title = (string)xev.Attribute("Title");
                        ds2.X_Title = (string)xev.Attribute("X_Title");
                        ds2.Y_Title = (string)xev.Attribute("Y_Title");

                        // Data :
                        var items = from dt in xev.Elements()
                                    select new
                                    {
                                        T = (string)dt.Attribute("Title"),
                                        x = (double)dt.Attribute("x"),
                                        y = (double)dt.Attribute("y")
                                    };
                        foreach (var dt in items)
                        {
                            ds2.Add(dt.T, dt.x, dt.y);
                        }
                    }
                    this.Reservoir.Evaporation = ds2;

                    //---------Infiltration :
                    ds2 = new DataSerie2D();
                    var xinf = resrvr.Element("Infiltration");
                    count = (int)xinf.Attribute("Count");
                    if (count > 0)
                    {
                        ds2.Name = (string)xinf.Attribute("Name");
                        ds2.Description = (string)xinf.Attribute("Description");
                        ds2.Title = (string)xinf.Attribute("Title");
                        ds2.X_Title = (string)xinf.Attribute("X_Title");
                        ds2.Y_Title = (string)xinf.Attribute("Y_Title");

                        // Data :
                        var items = from dt in xinf.Elements()
                                    select new
                                    {
                                        T = (string)dt.Attribute("Title"),
                                        x = (double)dt.Attribute("x"),
                                        y = (double)dt.Attribute("y")
                                    };
                        foreach (var dt in items)
                        {
                            ds2.Add(dt.T, dt.x, dt.y);
                        }
                    }
                    this.Reservoir.Infiltration = ds2;

                    //------------Inflow :
                  DataSerie1D  ds1 = new DataSerie1D();
                    var xq = resrvr.Element("Inflow");
                    count = (int)xq.Attribute("Count");
                    if (count > 0)
                    {
                        ds1.Name = (string)xq.Attribute("Name");
                        ds1.Description = (string)xq.Attribute("Description");
                        ds1.Title = (string)xq.Attribute("Title");
                        ds1.X_Title = (string)xq.Attribute("X_Title");

                        // Data :
                        var items = from dt in xq.Elements()
                                    select new
                                    {
                                        T = (string)dt.Attribute("Title"),
                                        x = (double)dt.Attribute("x"),
                                    };
                        foreach (var dt in items)
                        {
                            ds1.Add(dt.T, dt.x);
                        }
                    }
                    this.Reservoir.Inflow=ds1;

                    //-------------------------Downstream :

                    ds1 = new DataSerie1D();
                    var xd = resrvr.Element("Downstream");
                    count = (int)xd.Attribute("Count");
                    if (count > 0)
                    {
                        ds1.Name = (string)xd.Attribute("Name");
                        ds1.Description = (string)xd.Attribute("Description");
                        ds1.Title = (string)xd.Attribute("Title");
                        ds1.X_Title = (string)xd.Attribute("X_Title");

                        // Data :
                        var items = from dt in xd.Elements()
                                    select new
                                    {
                                        T = (string)dt.Attribute("Title"),
                                        x = (double)dt.Attribute("x"),
                                    };
                        foreach (var dt in items)
                        {
                            ds1.Add(dt.T, dt.x);
                        }
                    }
                    this.Reservoir.Downstream = ds1;
                                       
                }
            }
            catch (Exception ex) { throw ex;}
            this.FileName = filepath;
      }
    }
    public enum IOFileFormatEnum
    {
        DS =0,
        CSV=1,
        XML=3
    }
}
