// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.appDocumentosCEDIS.Controllers.Configuraciones
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using appDocumentosCEDIS.appDocumentosCEDIS.Entity;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Seguridad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml;

#nullable disable
namespace appDocumentosCEDIS.appDocumentosCEDIS.Controllers;

public class Configuraciones
{
  public CE_FTP FTP;
  public List<CE_Archivos> Archivos;
  public List<CE_Procesos> Procesos;
  public string regex;
  private string _RutaXML;

  public Configuraciones(object RutaXML)
  {
    IEnumerator enumerator1 = (IEnumerator) null;
    IEnumerator enumerator2 = (IEnumerator) null;
    this.FTP = new CE_FTP();
    this.Archivos = new List<CE_Archivos>();
    this.Procesos = new List<CE_Procesos>();
    DataSet Instance = new DataSet();
    object[] Arguments = new object[1]
    {
      RuntimeHelpers.GetObjectValue(RutaXML)
    };
    bool[] CopyBack = new bool[1]{ true };
    NewLateBinding.LateCall((object) Instance, (Type) null, "ReadXml", Arguments, (string[]) null, (Type[]) null, CopyBack, true);
    if (CopyBack[0])
      RutaXML = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Arguments[0]));
    this._RutaXML = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(RutaXML));
    try
    {
      this.FTP.Server = Security.DesEncriptar(global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(Instance.Tables[nameof (FTP)].Rows[0]["Server"])), "");
      this.FTP.User = Security.DesEncriptar(global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(Instance.Tables[nameof (FTP)].Rows[0]["User"])), "");
      this.FTP.Pass = Security.DesEncriptar(global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(Instance.Tables[nameof (FTP)].Rows[0]["Pass"])), "");
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      ProjectData.ClearProjectError();
    }
    try
    {
      try
      {
        foreach (DataRow row in Instance.Tables["Proceso"].Rows)
          this.Procesos.Add(new CE_Procesos()
          {
            id = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(row["id"])),
            descripcion = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(row["descripcion"])),
            esfoto = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(RuntimeHelpers.GetObjectValue(row["esfoto"]), (object) "1", false), (object) true, (object) false)))
          });
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      ProjectData.ClearProjectError();
    }
    try
    {
      this.regex = Instance.Tables[nameof (regex)].Rows[0]["value"].ToString();
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      ProjectData.ClearProjectError();
    }
    try
    {
      foreach (DataRow row in Instance.Tables["Archivo"].Rows)
      {
        try
        {
          this.Archivos.Add(new CE_Archivos()
          {
            carpeta = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(row["carpeta"])),
            descripcion = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(row["descripcion"])),
            ruta = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(row["ruta"])),
            estatus = global::appDocumentosCEDIS.Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(Interaction.IIf(Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(RuntimeHelpers.GetObjectValue(row["estatus"]), (object) "1", false), (object) true, (object) false))),
            id_num_doc = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(row["id_num_doc"]))
          });
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
    }
    finally
    {
      if (enumerator2 is IDisposable)
        (enumerator2 as IDisposable).Dispose();
    }
  }

  public void ActualizaEstatusXML()
  {
    IEnumerator enumerator1 = (IEnumerator) null;
    List<CE_Archivos>.Enumerator enumerator2 = new List<CE_Archivos>.Enumerator();
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(this._RutaXML);
    XmlElement documentElement = xmlDocument.DocumentElement;
    try
    {
      foreach (XmlNode selectNode in documentElement.SelectSingleNode("Archivos").SelectNodes("Archivo"))
      {
        try
        {
          foreach (CE_Archivos archivo in this.Archivos)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(selectNode.Attributes["id_num_doc"].Value, archivo.id_num_doc, false) == 0)
            {
              selectNode.Attributes["estatus"].Value = global::appDocumentosCEDIS.Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(archivo.estatus, (object) "1", (object) "0")));
              break;
            }
          }
        }
        finally
        {
          ((IDisposable) enumerator2).Dispose();
        }
      }
    }
    finally
    {
      if (enumerator1 is IDisposable)
        (enumerator1 as IDisposable).Dispose();
    }
    xmlDocument.Save(this._RutaXML);
  }
}
