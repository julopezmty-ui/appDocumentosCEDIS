// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.WCF_Documentos.InsertaArchivosVucemRequest
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;

#nullable disable
namespace appDocumentosCEDIS.WCF_Documentos;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "InsertaArchivosVucem", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class InsertaArchivosVucemRequest
{
  [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
  public DataTable dtArchivos;
  [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
  public string tabla;
  [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
  public string cadenaconexion;
  [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
  public string _Error;

  public InsertaArchivosVucemRequest()
  {
  }

  public InsertaArchivosVucemRequest(
    DataTable dtArchivos,
    string tabla,
    string cadenaconexion,
    string _Error)
  {
    this.dtArchivos = dtArchivos;
    this.tabla = tabla;
    this.cadenaconexion = cadenaconexion;
    this._Error = _Error;
  }
}
