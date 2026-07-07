// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.ManejoAWS
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using appDocumentosCEDIS.appDocumentosCEDIS.Controllers;
using AwsFileStorageNet;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Net.Http;

#nullable disable
namespace appDocumentosCEDIS;

public class ManejoAWS
{
  public static object sendFileS3(string referencedata, string onlyFileName, byte[] dataFile)
  {
        clsLog.SetLog("Autenticado FileStorage");

        FileStorageAPI.fileStorageEmail = "cedisvucem@grupoei.com.mx";
    FileStorageAPI.fileStoragePassword = "Linemex10@";
    FileStorageAPI.fileStorageUrl = "https://web.aduax.com/FileStorage/api/";
    FileStorageAPI.fileStorageApp = "CEDIS VUCEM";
    FileStorageAPI.IniciarSesion();
    FileStorageAPI.ObtenerTokenDeAplicacion();
    FileStorageAPI.VerificarToken();
    try
    {
      ByteArrayContent archivo = new ByteArrayContent(dataFile);
      string optionalPath = DateTime.Now.ToString("yyyy/MM/dd");
      return (object) FileStorageAPI.SubirArchivo("PEPA691104645", 2, referencedata, onlyFileName, archivo, optionalPath).UrlArchivo;
    }
    catch (Exception ex)
    {
      ProjectData.SetProjectError(ex);
      ProjectData.ClearProjectError();
    }
    return (object) string.Empty;
  }

    public static void sendFileS3(ref DataTable data)
    {
        foreach (DataRow row in data.Rows)
        {
            clsLog.SetLog("Enviando archivo a AWS");
            clsLog.SetLog("Referencia: " + row["Cve_Referencia"].ToString());
            clsLog.SetLog("Ruta: " + row["Ruta"].ToString());
            
            string referencedata = row["Cve_Referencia"].ToString();
            string str = row["Ruta"].ToString();
            string name = new FileInfo(str).Name;
            byte[] dataFile = File.ReadAllBytes(str);
            string Left = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ManejoAWS.sendFileS3(referencedata, name, dataFile));
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "", false) != 0)
            {
                row["RutaRemota"] = (object) Left;
                row["Estatus"] = (object) "A";
            }
            else
            {
                row["RutaRemota"] = (object) "";
                row["Estatus"] = (object) "E";
            }
        }
    }
}
