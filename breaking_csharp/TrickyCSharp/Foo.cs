using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace TrickyCSharp
{
  public partial class Foo : Form
  {
    public void CreateButtons(IList<string> labels)
    {
      foreach (String str in labels)
      {
        var btn = new Button();
        btn.Click += (sender, args) => MessageBox.Show(str);
      }
    }

    public void ProcessFiles([NotNull] int count)
    {
      var ofd = new OpenFileDialog();
      ofd.ShowDialog();
      var names = ofd.FileNames;

      BeginInvoke(new Action<string[]>(Process), ofd.FileNames);
    }

    private void Process(string[] files)
    {
      if (files.Count() > 0)
      {
        // process each of the files
        foreach (var file in files)
          ProcessFile(file);
      }
    }

    partial void ProcessFile(string filename);
  };
}
