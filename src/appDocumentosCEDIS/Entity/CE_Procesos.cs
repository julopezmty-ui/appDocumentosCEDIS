// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.appDocumentosCEDIS.Entity.CE_Procesos
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

using System.Diagnostics;

#nullable disable
namespace appDocumentosCEDIS.appDocumentosCEDIS.Entity;

public class CE_Procesos
{
  private string _id;
  private string _descripcion;
  private bool _esfoto;

  public string descripcion
  {
    get => this._descripcion;
    set => this._descripcion = value;
  }

  public string esfoto
  {
    get => Conversions.ToString((object) this._esfoto);
    set => this._esfoto = Conversions.ToBoolean((object) value);
  }

  public string id
  {
    get => this._id;
    set => this._id = value;
  }

  [DebuggerNonUserCode]
  public CE_Procesos()
  {
  }
}
