/*
Decompiled by Ptr35 (github.com/ktxxxx0828)
*/

using System.Text.RegularExpressions;

#nullable disable
namespace VisualBat
{
  internal class StringFinder
  {
    public bool DownSearch { get; set; }

    public string Src { get; set; }

    public string FindStr { get; set; }

    public string ReplaceStr { get; set; }

    public bool IgnoreCase { get; set; }

    public bool UseRegex { get; set; }

    public int ResultIndex { get; private set; }

    public int ResultLength { get; private set; }

    public string ResultReplaceStr { get; private set; }

    private string SrcIC => !this.IgnoreCase ? this.Src : this.Src.ToLower();

    private string FindStrIC => !this.IgnoreCase ? this.FindStr : this.FindStr.ToLower();

    private int regexIndexOf()
    {
      RegexOptions options = this.IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
      MatchCollection matchCollection = Regex.Matches(this.Src, this.FindStr, options);
      if (matchCollection.Count == 0)
        return -1;
      Match match = this.DownSearch ? matchCollection[0] : matchCollection[matchCollection.Count - 1];
      this.ResultLength = match.Length;
      if (this.ReplaceStr != null)
        this.ResultReplaceStr = Regex.Replace(this.Src, this.FindStr, this.ReplaceStr, options);
      return match.Index;
    }

    public void Search()
    {
      this.ResultLength = this.FindStr.Length;
      this.ResultReplaceStr = this.ReplaceStr;
      this.ResultIndex = this.UseRegex ? this.regexIndexOf() : (this.DownSearch ? this.SrcIC.IndexOf(this.FindStrIC) : this.SrcIC.LastIndexOf(this.FindStrIC));
    }
  }
}
