// Decompiled with JetBrains decompiler
// Type: appDocumentosCEDIS.Conversions
// Assembly: appDocumentosCEDIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D682BDA-0A32-4F25-B153-EB5FE4DE73D8
// Assembly location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.exe
// XML documentation location: C:\Users\Luis_\Downloads\appDocumentos Amazon - ALTERNO\appDocumentosCEDIS.xml

#nullable disable
namespace appDocumentosCEDIS;

public class Conversions
{
  public static string ToString(object value) => value == null ? "" : value.ToString();

  public static bool ToBoolean(object value)
  {
    bool result;
    return value != null && bool.TryParse(value.ToString(), out result) && result;
  }
}
