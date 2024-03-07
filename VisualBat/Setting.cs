/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using VisualBat.Properties;

#nullable disable
namespace VisualBat
{
  internal static class Setting
  {
    public static List<string> IdiomList { get; private set; }

    public static Dictionary<string, string> IdiomDic { get; private set; }

    public static string CommonDataFolder
    {
      get
      {
        return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\VisualBat";
      }
    }

    public static bool RememberLayout { get; set; }

    public static bool ShowFullPath { get; set; }

    public static bool CloseOnlyCurrentTab { get; set; }

    public static Color ForeColor { get; set; }

    public static Color BackColor { get; set; }

    public static Font EditorFont { get; set; }

    public static bool HighlightVar { get; set; }

    public static bool RememberTab { get; set; }

    public static int LastTabCount { get; set; }

    public static string LastFilePath { get; set; }

    public static List<string> LastFilePathList { get; set; }

    public static bool DumpForVar { get; set; }

    public static string ForVarChar { get; set; }

    public static bool DumpArg { get; set; }

    public static bool EndPause { get; set; }

    public static bool EnableInterruptCmd { get; set; }

    public static bool WasMaximum { get; set; }

    public static int LastX { get; set; }

    public static int LastY { get; set; }

    public static int LastWidth { get; set; }

    public static int LastHeight { get; set; }

    public static int LastCRX { get; set; }

    public static int LastCRY { get; set; }

    public static int LastCRWidth { get; set; }

    public static int LastCRHeight { get; set; }

    public static int CRReferenceVertical { get; set; }

    public static bool ShownToolBox { get; set; }

    public static bool ShownIdiom { get; set; }

    public static bool ShownCommandReference { get; set; }

    public static int MainVertical { get; set; }

    public static int EditHorizontal { get; set; }

    public static int IdiomVertical { get; set; }

    public static int DebugHorizontal { get; set; }

    public static int DumpVarGridNameWidth { get; set; }

    public static bool ShowTime { get; set; }

    public static bool ShowErrorLevel { get; set; }

    public static bool ExpandVar { get; set; }

    public static string WorkDirectory { get; set; }

    static Setting()
    {
      Setting.RememberLayout = false;
      Setting.ShowFullPath = false;
      Setting.CloseOnlyCurrentTab = false;
      Setting.ForeColor = Color.Black;
      Setting.BackColor = Color.White;
      Setting.EditorFont = Setting.strToFont("");
      Setting.HighlightVar = true;
      Setting.RememberTab = false;
      Setting.DumpForVar = false;
      Setting.ForVarChar = "IJK";
      Setting.DumpArg = false;
      Setting.EndPause = false;
      Setting.EnableInterruptCmd = false;
      Setting.ShowTime = true;
      Setting.ShowErrorLevel = true;
      Setting.ExpandVar = false;
      Setting.WorkDirectory = "";
    }

    public static void Load()
    {
      if (!Directory.Exists(Setting.CommonDataFolder))
        Directory.CreateDirectory(Setting.CommonDataFolder);
      string str1 = Setting.CommonDataFolder + "\\VisualBat.ini";
      try
      {
        if (!File.Exists(str1))
        {
          Setting.SaveSetting();
        }
        else
        {
          StringBuilder lpReturnedString = new StringBuilder(1024);
          int privateProfileString1 = (int) Win32Api.GetPrivateProfileString("Window", "Maximum", "0", lpReturnedString, 1024U, str1);
          Setting.WasMaximum = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString2 = (int) Win32Api.GetPrivateProfileString("Window", "X", "0", lpReturnedString, 1024U, str1);
          Setting.LastX = int.Parse(lpReturnedString.ToString());
          int privateProfileString3 = (int) Win32Api.GetPrivateProfileString("Window", "Y", "0", lpReturnedString, 1024U, str1);
          Setting.LastY = int.Parse(lpReturnedString.ToString());
          int privateProfileString4 = (int) Win32Api.GetPrivateProfileString("Window", "Width", "-1", lpReturnedString, 1024U, str1);
          Setting.LastWidth = int.Parse(lpReturnedString.ToString());
          int privateProfileString5 = (int) Win32Api.GetPrivateProfileString("Window", "Height", "0", lpReturnedString, 1024U, str1);
          Setting.LastHeight = int.Parse(lpReturnedString.ToString());
          int privateProfileString6 = (int) Win32Api.GetPrivateProfileString("Window", "CR_X", "0", lpReturnedString, 1024U, str1);
          Setting.LastCRX = int.Parse(lpReturnedString.ToString());
          int privateProfileString7 = (int) Win32Api.GetPrivateProfileString("Window", "CR_Y", "0", lpReturnedString, 1024U, str1);
          Setting.LastCRY = int.Parse(lpReturnedString.ToString());
          int privateProfileString8 = (int) Win32Api.GetPrivateProfileString("Window", "CR_Width", "-1", lpReturnedString, 1024U, str1);
          Setting.LastCRWidth = int.Parse(lpReturnedString.ToString());
          int privateProfileString9 = (int) Win32Api.GetPrivateProfileString("Window", "CR_Height", "0", lpReturnedString, 1024U, str1);
          Setting.LastCRHeight = int.Parse(lpReturnedString.ToString());
          int privateProfileString10 = (int) Win32Api.GetPrivateProfileString("Window", "CRReferenceVertical", "0", lpReturnedString, 1024U, str1);
          Setting.CRReferenceVertical = int.Parse(lpReturnedString.ToString());
          int privateProfileString11 = (int) Win32Api.GetPrivateProfileString("Window", "ToolBox", "0", lpReturnedString, 1024U, str1);
          Setting.ShownToolBox = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString12 = (int) Win32Api.GetPrivateProfileString("Window", "Idiom", "0", lpReturnedString, 1024U, str1);
          Setting.ShownIdiom = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString13 = (int) Win32Api.GetPrivateProfileString("Window", "CommandReference", "0", lpReturnedString, 1024U, str1);
          Setting.ShownCommandReference = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString14 = (int) Win32Api.GetPrivateProfileString("Window", "MainVertical", "0", lpReturnedString, 1024U, str1);
          Setting.MainVertical = int.Parse(lpReturnedString.ToString());
          int privateProfileString15 = (int) Win32Api.GetPrivateProfileString("Window", "EditHorizontal", "0", lpReturnedString, 1024U, str1);
          Setting.EditHorizontal = int.Parse(lpReturnedString.ToString());
          int privateProfileString16 = (int) Win32Api.GetPrivateProfileString("Window", "IdiomVertical", "0", lpReturnedString, 1024U, str1);
          Setting.IdiomVertical = int.Parse(lpReturnedString.ToString());
          int privateProfileString17 = (int) Win32Api.GetPrivateProfileString("Window", "DebugHorizontal", "0", lpReturnedString, 1024U, str1);
          Setting.DebugHorizontal = int.Parse(lpReturnedString.ToString());
          int privateProfileString18 = (int) Win32Api.GetPrivateProfileString("Window", "DumpVarGridNameWidth", "0", lpReturnedString, 1024U, str1);
          Setting.DumpVarGridNameWidth = int.Parse(lpReturnedString.ToString());
          int privateProfileString19 = (int) Win32Api.GetPrivateProfileString("Window", "RememberLayout", "0", lpReturnedString, 1024U, str1);
          Setting.RememberLayout = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString20 = (int) Win32Api.GetPrivateProfileString("Window", "ShowFullPath", "0", lpReturnedString, 1024U, str1);
          Setting.ShowFullPath = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString21 = (int) Win32Api.GetPrivateProfileString("Window", "CloseOnlyCurrentTab", "0", lpReturnedString, 1024U, str1);
          Setting.CloseOnlyCurrentTab = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString22 = (int) Win32Api.GetPrivateProfileString("Window", "ForeColor", "0,0,0", lpReturnedString, 1024U, str1);
          Setting.ForeColor = Setting.strToColor(lpReturnedString.ToString());
          int privateProfileString23 = (int) Win32Api.GetPrivateProfileString("Window", "BackColor", "255,255,255", lpReturnedString, 1024U, str1);
          Setting.BackColor = Setting.strToColor(lpReturnedString.ToString());
          int privateProfileString24 = (int) Win32Api.GetPrivateProfileString("Editor", "Font", "", lpReturnedString, 1024U, str1);
          Setting.EditorFont = Setting.strToFont(lpReturnedString.ToString());
          int privateProfileString25 = (int) Win32Api.GetPrivateProfileString("Editor", "HighlightVar", "1", lpReturnedString, 1024U, str1);
          Setting.HighlightVar = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString26 = (int) Win32Api.GetPrivateProfileString("Editor", "RememberTab", "0", lpReturnedString, 1024U, str1);
          Setting.RememberTab = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString27 = (int) Win32Api.GetPrivateProfileString("Editor", "LastTabCount", "0", lpReturnedString, 1024U, str1);
          Setting.LastTabCount = int.Parse(lpReturnedString.ToString());
          int privateProfileString28 = (int) Win32Api.GetPrivateProfileString("Editor", "LastFilePath", "", lpReturnedString, 1024U, str1);
          Setting.LastFilePath = lpReturnedString.ToString();
          Setting.LastFilePathList = new List<string>();
          for (int index = 0; index < Setting.LastTabCount; ++index)
          {
            int privateProfileString29 = (int) Win32Api.GetPrivateProfileString("Editor", "LastFilePathList" + (object) index, "", lpReturnedString, 1024U, str1);
            Setting.LastFilePathList.Add(lpReturnedString.ToString());
          }
          int privateProfileString30 = (int) Win32Api.GetPrivateProfileString("Debug", "DumpForVar", "0", lpReturnedString, 1024U, str1);
          Setting.DumpForVar = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString31 = (int) Win32Api.GetPrivateProfileString("Debug", "ForVarChar", "IJK", lpReturnedString, 1024U, str1);
          Setting.ForVarChar = lpReturnedString.ToString();
          int privateProfileString32 = (int) Win32Api.GetPrivateProfileString("Debug", "DumpArg", "0", lpReturnedString, 1024U, str1);
          Setting.DumpArg = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString33 = (int) Win32Api.GetPrivateProfileString("Debug", "EndPause", "0", lpReturnedString, 1024U, str1);
          Setting.EndPause = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString34 = (int) Win32Api.GetPrivateProfileString("Debug", "EnableInterruptCmd", "0", lpReturnedString, 1024U, str1);
          Setting.EnableInterruptCmd = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString35 = (int) Win32Api.GetPrivateProfileString("Debug", "ShowTime", "1", lpReturnedString, 1024U, str1);
          Setting.ShowTime = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString36 = (int) Win32Api.GetPrivateProfileString("Debug", "ShowErrorLevel", "1", lpReturnedString, 1024U, str1);
          Setting.ShowErrorLevel = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString37 = (int) Win32Api.GetPrivateProfileString("Debug", "ExpandVar", "0", lpReturnedString, 1024U, str1);
          Setting.ExpandVar = Setting.strToBool(lpReturnedString.ToString());
          int privateProfileString38 = (int) Win32Api.GetPrivateProfileString("Debug", "WorkDirectory", "", lpReturnedString, 1024U, str1);
          Setting.WorkDirectory = lpReturnedString.ToString();
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("設定ファイルの読み込みに失敗しました。");
      }
      string str2 = Setting.CommonDataFolder + "\\idiom.xml";
      try
      {
        if (!File.Exists(str2))
          Setting.saveDefaultIdiom();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(str2);
        Setting.IdiomList = new List<string>();
        Setting.IdiomDic = new Dictionary<string, string>();
        foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
        {
          string key = childNode["Name"].FirstChild.Value;
          Setting.IdiomList.Add(key);
          Setting.IdiomDic[key] = childNode["Text"].FirstChild.Value;
        }
      }
      catch
      {
      }
    }

    private static XmlDocument createNewIdiomXml()
    {
      XmlDocument newIdiomXml = new XmlDocument();
      newIdiomXml.AppendChild((XmlNode) newIdiomXml.CreateXmlDeclaration("1.0", "Shift_JIS", (string) null));
      newIdiomXml.AppendChild((XmlNode) newIdiomXml.CreateElement("root"));
      return newIdiomXml;
    }

    private static void saveDefaultIdiom()
    {
      Setting.IdiomList = new List<string>();
      Setting.IdiomDic = new Dictionary<string, string>();
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(Resources.DefaultIdiomXml);
      try
      {
        xmlDocument.Save(Setting.CommonDataFolder + "\\idiom.xml");
      }
      catch
      {
      }
    }

    public static void SaveIdiom()
    {
      XmlDocument newIdiomXml = Setting.createNewIdiomXml();
      foreach (string idiom in Setting.IdiomList)
      {
        XmlElement element1 = newIdiomXml.CreateElement("Idiom");
        newIdiomXml.DocumentElement.AppendChild((XmlNode) element1);
        XmlElement element2 = newIdiomXml.CreateElement("Name");
        element2.InnerText = idiom;
        element1.AppendChild((XmlNode) element2);
        XmlElement element3 = newIdiomXml.CreateElement("Text");
        element3.InnerText = Setting.IdiomDic[idiom];
        element1.AppendChild((XmlNode) element3);
      }
      bool flag = false;
      try
      {
        newIdiomXml.Save(Setting.CommonDataFolder + "\\idiom.xml");
        flag = true;
      }
      catch
      {
      }
      if (flag)
        return;
      int num = (int) MessageBox.Show("イディオムの保存に失敗しました。");
    }

    private static string boolToStr(bool src) => !src ? "0" : "1";

    private static bool strToBool(string src) => src == "1";

    public static string FontToStr(Font src)
    {
      int num = ((src.Style & FontStyle.Bold) == FontStyle.Bold ? 1 : 0) + ((src.Style & FontStyle.Italic) == FontStyle.Italic ? 2 : 0);
      return src.FontFamily.Name + ":" + (object) num + ":" + (object) src.SizeInPoints;
    }

    private static Font strToFont(string src)
    {
      if (src == "")
        return new Font("ＭＳ ゴシック", 12f, FontStyle.Regular);
      string[] strArray = src.Split(':');
      int num = int.Parse(strArray[1]);
      FontStyle style = (FontStyle) (((num & 1) > 0 ? 1 : 0) | ((num & 2) > 0 ? 2 : 0));
      return new Font(strArray[0], float.Parse(strArray[2]), style);
    }

    private static string colorToStr(Color src)
    {
      return string.Format("{0},{1},{2}", (object) src.R, (object) src.G, (object) src.B);
    }

    private static Color strToColor(string src)
    {
      string[] strArray = src.Split(',');
      return Color.FromArgb(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]));
    }

    public static void SaveSetting()
    {
      string lpFileName = Setting.CommonDataFolder + "\\VisualBat.ini";
      try
      {
        int num1 = (int) Win32Api.WritePrivateProfileString("Window", "Maximum", Setting.boolToStr(Setting.WasMaximum), lpFileName);
        int num2 = (int) Win32Api.WritePrivateProfileString("Window", "X", string.Concat((object) Setting.LastX), lpFileName);
        int num3 = (int) Win32Api.WritePrivateProfileString("Window", "Y", string.Concat((object) Setting.LastY), lpFileName);
        int num4 = (int) Win32Api.WritePrivateProfileString("Window", "Width", string.Concat((object) Setting.LastWidth), lpFileName);
        int num5 = (int) Win32Api.WritePrivateProfileString("Window", "Height", string.Concat((object) Setting.LastHeight), lpFileName);
        int num6 = (int) Win32Api.WritePrivateProfileString("Window", "CR_X", string.Concat((object) Setting.LastCRX), lpFileName);
        int num7 = (int) Win32Api.WritePrivateProfileString("Window", "CR_Y", string.Concat((object) Setting.LastCRY), lpFileName);
        int num8 = (int) Win32Api.WritePrivateProfileString("Window", "CR_Width", string.Concat((object) Setting.LastCRWidth), lpFileName);
        int num9 = (int) Win32Api.WritePrivateProfileString("Window", "CR_Height", string.Concat((object) Setting.LastCRHeight), lpFileName);
        int num10 = (int) Win32Api.WritePrivateProfileString("Window", "CRReferenceVertical", string.Concat((object) Setting.CRReferenceVertical), lpFileName);
        int num11 = (int) Win32Api.WritePrivateProfileString("Window", "ToolBox", Setting.boolToStr(Setting.ShownToolBox), lpFileName);
        int num12 = (int) Win32Api.WritePrivateProfileString("Window", "Idiom", Setting.boolToStr(Setting.ShownIdiom), lpFileName);
        int num13 = (int) Win32Api.WritePrivateProfileString("Window", "CommandReference", Setting.boolToStr(Setting.ShownCommandReference), lpFileName);
        int num14 = (int) Win32Api.WritePrivateProfileString("Window", "MainVertical", string.Concat((object) Setting.MainVertical), lpFileName);
        int num15 = (int) Win32Api.WritePrivateProfileString("Window", "EditHorizontal", string.Concat((object) Setting.EditHorizontal), lpFileName);
        int num16 = (int) Win32Api.WritePrivateProfileString("Window", "IdiomVertical", string.Concat((object) Setting.IdiomVertical), lpFileName);
        int num17 = (int) Win32Api.WritePrivateProfileString("Window", "DebugHorizontal", string.Concat((object) Setting.DebugHorizontal), lpFileName);
        int num18 = (int) Win32Api.WritePrivateProfileString("Window", "DumpVarGridNameWidth", string.Concat((object) Setting.DumpVarGridNameWidth), lpFileName);
        int num19 = (int) Win32Api.WritePrivateProfileString("Window", "RememberLayout", Setting.boolToStr(Setting.RememberLayout), lpFileName);
        int num20 = (int) Win32Api.WritePrivateProfileString("Window", "ShowFullPath", Setting.boolToStr(Setting.ShowFullPath), lpFileName);
        int num21 = (int) Win32Api.WritePrivateProfileString("Window", "CloseOnlyCurrentTab", Setting.boolToStr(Setting.CloseOnlyCurrentTab), lpFileName);
        int num22 = (int) Win32Api.WritePrivateProfileString("Window", "ForeColor", Setting.colorToStr(Setting.ForeColor), lpFileName);
        int num23 = (int) Win32Api.WritePrivateProfileString("Window", "BackColor", Setting.colorToStr(Setting.BackColor), lpFileName);
        int num24 = (int) Win32Api.WritePrivateProfileString("Editor", "Font", Setting.FontToStr(Setting.EditorFont), lpFileName);
        int num25 = (int) Win32Api.WritePrivateProfileString("Editor", "HighlightVar", Setting.boolToStr(Setting.HighlightVar), lpFileName);
        int num26 = (int) Win32Api.WritePrivateProfileString("Editor", "RememberTab", Setting.boolToStr(Setting.RememberTab), lpFileName);
        int num27 = (int) Win32Api.WritePrivateProfileString("Editor", "LastTabCount", string.Concat((object) Setting.LastTabCount), lpFileName);
        int num28 = (int) Win32Api.WritePrivateProfileString("Editor", "LastFilePath", Setting.LastFilePath, lpFileName);
        for (int index = 0; index < Setting.LastTabCount; ++index)
        {
          int num29 = (int) Win32Api.WritePrivateProfileString("Editor", "LastFilePathList" + (object) index, Setting.LastFilePathList[index], lpFileName);
        }
        int num30 = (int) Win32Api.WritePrivateProfileString("Debug", "DumpForVar", Setting.boolToStr(Setting.DumpForVar), lpFileName);
        int num31 = (int) Win32Api.WritePrivateProfileString("Debug", "ForVarChar", Setting.ForVarChar, lpFileName);
        int num32 = (int) Win32Api.WritePrivateProfileString("Debug", "DumpArg", Setting.boolToStr(Setting.DumpArg), lpFileName);
        int num33 = (int) Win32Api.WritePrivateProfileString("Debug", "EndPause", Setting.boolToStr(Setting.EndPause), lpFileName);
        int num34 = (int) Win32Api.WritePrivateProfileString("Debug", "EnableInterruptCmd", Setting.boolToStr(Setting.EnableInterruptCmd), lpFileName);
        int num35 = (int) Win32Api.WritePrivateProfileString("Debug", "ShowTime", Setting.boolToStr(Setting.ShowTime), lpFileName);
        int num36 = (int) Win32Api.WritePrivateProfileString("Debug", "ShowErrorLevel", Setting.boolToStr(Setting.ShowErrorLevel), lpFileName);
        int num37 = (int) Win32Api.WritePrivateProfileString("Debug", "ExpandVar", Setting.boolToStr(Setting.ExpandVar), lpFileName);
        int num38 = (int) Win32Api.WritePrivateProfileString("Debug", "WorkDirectory", Setting.WorkDirectory, lpFileName);
      }
      catch
      {
      }
    }
  }
}
