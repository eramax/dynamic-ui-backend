using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicUi.App_Start
{
    public class BM : Ui
    {
        public BM(string tag, string classes = null, string _id = null, string content = null) : base(tag, classes, _id, content)
        {
        }
        public BM addTo(ref BM t)
        {
            t.Childerns.Add(this);
            return this;
        }
        public static BM operator +(BM left, BM right)
        {
            left.Childerns.Add(right);
            return left;
        }
        public BM add(params BM[] t)
        {
            Childerns.AddRange(t);
            return this;
        }

        public BM Is(int x) { Props["className"] += " is-" + x; return this; }

        public BM IsDesktop(string x) { Props["className"] += " is-desktop"; return this; }
        public BM IsMobile(string x) { Props["className"] += " is-mobile"; return this; }

        public BM Mobile(int x) { Props["className"] += " is-" + x + "-mobile"; return this; }
        public BM Tablet(int x) { Props["className"] += " is-" + x + "-tablet"; return this; }
        public BM Desktop(int x) { Props["className"] += " is-" + x + "-desktop"; return this; }
        public BM Wide(int x) { Props["className"] += " is-" + x + "-widescreen"; return this; }
        public BM FullHD(int x) { Props["className"] += " is-" + x + "-fullhd"; return this; }

        public BM IsFluid() { Props["className"] += " is-fluid"; return this; }
        public BM IsRight() { Props["className"] += " is-right"; return this; }
        public BM IsLeft() { Props["className"] += " is-left"; return this; }

        public BM IsCentered() { Props["className"] += " is-centered"; return this; }
        public BM IsHalf() { Props["className"] += " is-half"; return this; }
        public BM IsMultiline() { Props["className"] += " is-multiline"; return this; }
        public BM IsNarrow() { Props["className"] += " is-narrow"; return this; }

        public BM IsSmall() { Props["className"] += " is-small"; return this; }
        public BM IsMedium() { Props["className"] += " is-medium"; return this; }
        public BM IsLarge() { Props["className"] += " is-large"; return this; }

        public BM IsWhite() { Props["className"] += " is-white"; return this; }
        public BM IsLight() { Props["className"] += " is-light"; return this; }
        public BM IsDark() { Props["className"] += " is-dark"; return this; }
        public BM IsBlack() { Props["className"] += " is-black"; return this; }
        public BM IsLink() { Props["className"] += " is-link"; return this; }

        public BM IsPrimary() { Props["className"] += " is-primary"; return this; }
        public BM IsInfo() { Props["className"] += " is-info"; return this; }
        public BM IsSuccess() { Props["className"] += " is-success"; return this; }
        public BM IsWarning() { Props["className"] += " is-warning"; return this; }
        public BM IsDanger() { Props["className"] += " is-danger"; return this; }

        public BM IsOutlined() { Props["className"] += " is-outlined"; return this; }
        public BM IsInverted() { Props["className"] += " is-inverted"; return this; }

        public BM IsButton() { Props["className"] += " button"; return this; }
        public BM IsHovered() { Props["className"] += " is-hovered"; return this; }
        public BM IsFocused() { Props["className"] += " is-focused"; return this; }
        public BM IsActive() { Props["className"] += " is-active"; return this; }
        public BM IsLoading() { Props["className"] += " is-loading"; return this; }

        public BM IsNavItem() { Props["className"] += " nav-item"; return this; }
        public BM IsNavMenu() { Props["className"] += " nav-menu"; return this; }

        public BM IsMenuList() { Props["className"] += " menu-list"; return this; }

        public static BM Div(string classes = null, string content = null) { return new BM(Tag.div,  classes, null, content); }
        public static BM Conainer(string classes = null) { return new BM(Tag.div, "container" + classes); }
        public static BM Row(string classes = null) { return new BM(Tag.div, "columns" + classes); }
        public static BM Col(int desktop, int mobile, string classes = null)
        { return new BM(Tag.div, "column").Mobile(mobile).Desktop(desktop).Wide(desktop).FullHD(desktop).Tablet(mobile); }
        public static BM Section(string classes = null) { return new BM(Tag.section, "section" + classes); }
        public static BM Buttun(string classes = null, string content = null) { return new BM(Tag.button, "button" + classes,null,content); }
        public static BM P(string content = null) { return new BM(Tag.p, "content",null,content); }
        public static BM Box(string classes = null) { return new BM(Tag.div, "box" + classes); }
        public static BM Notification(string content = null)
        { return new BM(Tag.p, "notification", null, content).add(Buttun("delete")); }
        public static BM tag(string content) { return new BM(Tag.span, "tag",null, content); }
        public static BM Article(string title, string content)
        { return new BM(Tag.Article, "message").add(Div("message-header", title), Div("message-body", content)); }

        public static BM Nav(string brandImage, string brandLink , BM left, BM right)
        {
            var ar = new BM(Tag.nav, "navbar").role("navigation").aria_label("main navigation") as BM;
            var d1 = Div("navbar-brand");
            d1 += A(brandLink).Class("navbar-item").add(Img(brandImage, 0, 0)) as BM;
            d1 += new BM(Tag.a, "navbar-burger burger").aria_label("menu").role("button").aria_expanded("false").data_target("navbarBasicExample").add(
                Span().aria_hidden("true"), Span().aria_hidden("true"), Span().aria_hidden("true") ) as BM;
            var d2 = new BM(Tag.div, "navbar-menu", "navbarBasicExample").add(left, right);
            ar += d1;
            ar += d2;
            return ar;
        }
        public static BM MenuGroup(string label, BM ul)
        { return Div().add(new BM(Tag.p, "menu-label", null, label), ul.IsMenuList()); }

        public static BM Menu() { return new BM(Tag.Aside, "menu");  }
        public static BM A(string link, string content=null, string classes = null) { return new BM(Tag.a, classes, null, content).href(link) as BM; }

    }
    public class BmBuilder
    {
        public Layout build1()
        {
            BM warpper = BM.Div("wpp");
            var con = BM.Conainer().addTo(ref warpper);
            var rows = BM.Row();
            con.add(rows);
            var col1 = BM.Col(6, 12).Mobile(6).addTo(ref rows);
            var col2 = BM.Col(6, 12).addTo(ref rows);
            col1 += BM.Buttun(null, "Button1").IsPrimary();
            col1 += BM.Buttun(null, "Button2").IsDanger();

            col2 += BM.Buttun(null, "Button3").IsInfo();
            col2 += BM.Buttun(null, "Button4").IsSuccess();
            col2 += BM.Buttun(null, "Button4").IsWarning();

            Layout layout = new Layout("bm1");
            layout.Components = warpper;

            return layout;
        }

        public Layout build2()
        {
            Layout layout = new Layout("bm1");
            BM warpper = BM.Div("wpp22");
            layout.Components = warpper;
            var con = BM.Conainer().IsFluid().addTo(ref warpper);
            var navStart = BM.Div("navbar-start").add(
                BM.A("/","Home", "navbar-item"),
                BM.A("/about", "About", "navbar-item"),
                BM.A("/users", "Users", "navbar-item"),
                BM.A("/reports", "Reports", "navbar-item")
                );

            var navEnd = BM.Div("navbar-end").add(
                BM.A("/notify", "Notifications", "navbar-item"),
                BM.A("/logout", "Logout", "navbar-item")
                );

            var nav = BM.Nav("https://bulma.io/images/bulma-logo.png", "/", navStart, navEnd);
            con += nav;
            return layout;
        }
    }
    public class Layout
    {
        public string LayoutName;
        public BM Components;
        public Layout(string name) { LayoutName = name; }
    }
}
