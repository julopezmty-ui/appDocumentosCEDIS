// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.WCF_Documentos.InsertaArchivosVucemResponse
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

#nullable disable
namespace appDocumentosCEDIS.WCF_Documentos;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "InsertaArchivosVucemResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class InsertaArchivosVucemResponse
{
  [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
  public bool InsertaArchivosVucemResult;
  [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
  public string _Error;

  public InsertaArchivosVucemResponse()
  {
  }

  public InsertaArchivosVucemResponse(bool InsertaArchivosVucemResult, string _Error)
  {
    this.InsertaArchivosVucemResult = InsertaArchivosVucemResult;
    this._Error = _Error;
  }
}
