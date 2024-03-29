﻿// Decompiled with JetBrains decompiler
// Type: i_Tree_Eco_v6.Forms.PaperForm
// Assembly: i-Tree Eco v6.x64, Version=6.0.29.0, Culture=neutral, PublicKeyToken=null
// MVID: E695D7ED-407B-4C7B-B817-3F1C5BB20211
// Assembly location: C:\Program Files (x86)\i-Tree\EcoV6\i-Tree Eco v6.x64.exe

using CefSharp;
using i_Tree_Eco_v6.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace i_Tree_Eco_v6.Forms
{
  public class PaperForm : CustomWebBrowserForm
  {
    public PaperForm() => this.InitializeComponent();

    protected override string Url => Strings.UrlPaperForm;

    protected override void OfflinePage()
    {
      HtmlAgilityPack.HtmlDocument htmlDocument1 = this.CreateBase();
      HtmlAgilityPack.HtmlDocument htmlDocument2 = new HtmlAgilityPack.HtmlDocument();
      htmlDocument2.LoadHtml(i_Tree_Eco_v6.Properties.Resources.PaperFormTemplate);
      htmlDocument1.GetElementbyId("content").InnerHtml = htmlDocument2.GetElementbyId("content").InnerHtml;
      htmlDocument1.GetElementbyId("footer-header").InnerHtml = htmlDocument2.GetElementbyId("footer-header").InnerHtml;
      this.Browser.LoadHtml(htmlDocument1.DocumentNode.OuterHtml, this.Url);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.lblBreadcrumb.Size = new Size(670, 29);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(670, 529);
      this.Name = "PapperForm";
      this.Text = "Papper forms";
      this.ResumeLayout(false);
    }
  }
}
