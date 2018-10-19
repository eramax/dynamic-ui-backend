using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DynamicUi.Controllers
{
    public class UiFramework
    {
        
        
    }
    public enum Tg
    {
        html,
        head,
        title,
        body,
        ul,
        li,
        ol,
        a,
        button,
        br,
        code,
        div,
        form,
        header,
        option,
        select,
        textarea,
        table,
        tbody,
        td,
        tfoot,
        th,
        thead,
        span,
        section,
        script,
        img,
        input,
        nav,
        p,
        h1,
        h2,
        h3,
        h4,
        

    }
    public class Tag
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Tg type;
        public string id;
        public string className;
        public string data;
        public List<Tag> childrens = new List<Tag>();
        public Tag() { }
        public Tag(Tg t,string _className = null, string _data = null, string _id = null)
        { type = t; data = _data; className = _className; id = _id; }
        public Tag add(Tag t)
        {
            childrens.Add(t);
            return this;
        }
        public Tag add(Tg t, string _className = null, string _data = null, string _id = null)
        {
            Tag nt = new Tag(t, _className, _data, _id);
            childrens.Add(nt);
            return this;
        }
        public static Tag operator +(Tag left, Tag right)
        {
            left.childrens.Add(right);
            return left;
        }
    }
    public class Page
    {
        public Tag html { get; set; }
        public Page()
        {
            html = new Tag(Tg.html);
        }
    }
    public class TestUi
    {
        public Tag ctg(Tg t, string _className = null, string _data = null, string _id = null)
        {
            return new Tag(t, _className, _data, _id);
        }

        public object buildPage()
        {
            Page pg = new Page();
            Tag body = new Tag(Tg.body);
            pg.html += body;
            Tag divContainer = new Tag(Tg.div, "container");
            body += divContainer;
            Tag nav = new Tag(Tg.nav, "navbar navbar-light bg-light") + new Tag(Tg.span, "navbar-text", "hello");
            divContainer += nav;
            Tag divRaw = new Tag(Tg.div, "row");
            divContainer += divRaw;
            divRaw += new Tag(Tg.div, "col-4");
            divRaw += new Tag(Tg.div, "col-8");


            return pg.html;
        }
        public object buildPage2()
        {
            Tag con = new Tag(Tg.div, "container");
            var x = new Tag(Tg.nav, "navbar navbar-light bg-light") + new Tag(Tg.h1, "navbar-brand","Welcome");
            con += new Tag(Tg.div, "row") + x;
            return con;
        }
        public object buildPage3()
        {
            var x = ctg(Tg.div, "container").add(ctg(Tg.div, "row").add(Tg.h1, "danger", "Welcome 2019")).add(Tg.a,"form-control","#");
            return x;
        }
        public object buildPage4()
        {
            var con = ctg(Tg.div, "container");
            var row1 = ctg(Tg.div, "row grow w-100");
            row1.add(ctg(Tg.div, "col-12 bg-primary py-3", "Header"));
            row1.add(ctg(Tg.div, "col-4 bg-info py-3", "Menu"));
            var dv1 = ctg(Tg.div, "main col-8 bg-warning h-100 py-3");
            dv1.add(Tg.h1, null, "Main");
            dv1.add(Tg.p, "mb-5", "adadasdadadadadadsf fdsfas sdfsd sf fasfsafsdafsa sfsafas fsadfasd fsadfas f ");
            dv1.add(Tg.button, "btn btn-primary", "UpdateLayout");
            row1.add(dv1);
            con += row1;
            var row2 = ctg(Tg.div, "row w-100");
            row2.add(Tg.div, "col-12 py-3 bg-danger", "Footer");
            con += row2;
            return con;
        }
        public object buildPage5()
        {
            var con = ctg(Tg.div, "container");
            var row1 = ctg(Tg.div, "row grow w-100");
            row1.add(ctg(Tg.div, "col-12 bg-primary py-3", "Header"));
            row1.add(ctg(Tg.div, "col-4 bg-info py-3", "Menu"));
            var dv1 = ctg(Tg.div, "main col-8 bg-warning h-100 py-3");
            dv1.add(Tg.h1, null, "Main");
            dv1.add(Tg.p, "mb-5", "adadasdadadadadadsf fdsfas sdfsd sf fasfsafsdafsa sfsafas fsadfasd fsadfas f ");
            dv1.add(Tg.button, "btn btn-primary", "LoadModal");
            row1.add(dv1);
            con += row1;
            var row2 = ctg(Tg.div, "row w-100");
            row2.add(Tg.div, "col-12 py-3 bg-danger", "Footer");
            con += row2;
            return con;
        }


    }


}