using System.Collections.Generic;

namespace DynamicUi
{
    public class Ui
    {
        public string Type;
        public string Key;
        public string id;
        public string Content;
        public List<string> Vars = new List<string>();
        public Dictionary<string, object> Props = new Dictionary<string, object>();
        public List<Ui> Childerns = new List<Ui>();

        public Ui(string tag, string classes = null, string _id = null, string content = null)
        {
            Type = tag;
            Key = System.Guid.NewGuid().ToString("N").Substring(0, 10);
            id = _id;
            Content = content;
            Props.Add("className", classes);
        }
        public static Ui operator +(Ui left, Ui right)
        {
            left.Childerns.Add(right);
            return left;
        }
        public Ui add(params Ui[] t)
        {
            Childerns.AddRange(t);
            return this;
        }
        public Ui addTo(ref Ui t)
        {
            t.Childerns.Add(this);
            return this;
        }

        public Ui AddVar(string x) { Vars.Add(x); return this; }

        public Ui Class(string x) { Props["className"] += x; return this; }
        public Ui type(string x) { Props.Add("type", x); return this; }
        public Ui href(string x) { Props.Add("href", x); return this; }

        public Ui src(string x) { Props.Add("src", x); return this; }

        public Ui For(string x) { Props.Add("for", x); return this; }

        public Ui OnClick(string functionName, params string[] vars)
        {
            var dir = new Dictionary<string, object>(); dir.Add("function", functionName);
            dir.Add("vars", vars); Props.Add("onClick", dir); return this;
        }
        public Ui OnChange(string functionName, params string[] vars)
        {
            var dir = new Dictionary<string, object>(); dir.Add("function", functionName);
            dir.Add("vars", vars); Props.Add("onChange", dir); return this;
        }
        public Ui hidden() { Props.Add("hidden", true); return this; }
        public Ui disabled() { Props.Add("disabled", true); return this; }

        public Ui role(string x) { Props.Add("role", x); return this; }
        public Ui aria_label(string x) { Props.Add("aria-label", x); return this; }
        public Ui aria_expanded(string x) { Props.Add("aria-expanded", x); return this; }
        public Ui data_target(string x) { Props.Add("data-target", x); return this; }
        public Ui aria_hidden(string x) { Props.Add("aria-hidden", x); return this; }


        public static B4 Div(string classes = null) { return new B4(Tag.div, classes); }
        public static Ui H1(string content) { return new Ui(Tag.h1, null, null, content); }
        public static Ui H2(string content) { return new Ui(Tag.h2, null, null, content); }
        public static Ui H3(string content) { return new Ui(Tag.h3, null, null, content); }
        public static Ui H4(string content) { return new Ui(Tag.h4, null, null, content); }
        public static Ui P(string content) { return new Ui(Tag.p, null, null, content); }
        public static Ui Span() { return new Ui(Tag.span); }
        public static Ui Img(string link, int width, int height) { return new Ui("Img").src(link); }
    }
    public class B4 : Ui
    {
        public B4(string tag, string classes = null, string _id = null, string content = null) : base(tag, classes, _id, content)
        {
        }

        public B4 addTo(ref B4 t)
        {
            t.Childerns.Add(this);
            return this;
        }
        public static B4 operator +(B4 left, B4 right)
        {
            left.Childerns.Add(right);
            return left;
        }
        public B4 tabindex(string x) { Props.Add("tabIndex", x); return this; }
        public B4 check(string x) { Props.Add("check", x); return this; }
        public B4 xs(int? x) { Props.Add("xs", x?.ToString()); return this; }
        public B4 sm(int? x) { Props.Add("sm", x?.ToString()); return this; }
        public B4 md(int? x) { Props.Add("md", x?.ToString()); return this; }
        public B4 placeholder(string x) { Props.Add("placeholder", x); return this; }
        public B4 bsSize(string x) { Props.Add("bsSize", x); return this; }
        public B4 label(string x) { Props.Add("label", x); return this; }
        public B4 color(string x) { Props.Add("color", x); return this; }
        public B4 data_toggle(string x) { Props.Add("data_toggle", x); return this; }
        public B4 aria_labelledby(string x) { Props.Add("aria_labelledby", x); return this; }
        public B4 data_dismiss(string x) { Props.Add("data_dismiss", x); return this; }
        public B4 tag(string x) { Props.Add("tag", x); return this; }
        public B4 Form() { Props.Add("form", true); return this; }
        public B4 inline() { Props.Add("inline", true); return this; }
        public B4 valid() { Props.Add("valid", true); return this; }
        public B4 invalid() { Props.Add("invalid", true); return this; }
        public B4 tooltip() { Props.Add("tooltip", true); return this; }
        public B4 plaintext() { Props.Add("plaintext", true); return this; }
        public B4 row() { Props.Add("row", true); return this; }
        public B4 multiple() { Props.Add("multiple", true); return this; }
        public B4 fluid() { Props.Add("fluid", true); return this; }
        public B4 active() { Props.Add("active", true); return this; }

        public static B4 Conainer(string classes = null) { return new B4(Tag.Container); }
        public static B4 Row(string classes = null) { return new B4(Tag.Row, classes); }
        public static B4 Col(int? x = null, string classes = null) { return new B4(Tag.Col, classes, null, null).xs(x).sm(x); }


        public B4 isOpen(string functionName, params string[] vars)
        {
            var dir = new Dictionary<string, object>(); dir.Add("function", functionName);
            dir.Add("vars", vars); Props.Add("isOpen", dir); return this;
        }
        public B4 toggle(string functionName, params string[] vars)
        {
            var dir = new Dictionary<string, object>(); dir.Add("function", functionName);
            dir.Add("vars", vars); Props.Add("toggle", dir); return this;
        }

        public static B4 Button(string content, string color = null, string action = null, params string[] vars)
        { return new B4(Tag.Button, null, null, content).color(color).OnClick(action, vars) as B4; }
        public static B4 Modal(string _id, Ui body, string title, Ui buttons)
        {
            var modal = new B4(Tag.Modal, null, _id, null).isOpen("getVar", _id).toggle("toggleModal", _id).AddVar(_id).AddVar("isOpenModal2");
            modal += new B4(Tag.ModalHeader, null, null, title).toggle("toggleModal", _id);
            modal += new B4(Tag.ModalBody).add(body);
            modal += new B4(Tag.ModalFooter).add(buttons);
            return modal as B4;
        }
        public static B4 MenuListItem(string content, string link) { return new B4(Tag.ListGroupItem, null, null, content).tag("button").href(link) as B4; }
        public static B4 MenuListGroup(params B4[] list) { list[0].active(); return new B4(Tag.ListGroup).add(list) as B4; }
    }
    public class Tag
    {
        public const string
        Alert = "Alert",
        Badge = "Badge",
        Breadcrumb = "Breadcrumb",
        BreadcrumbItem = "BreadcrumbItem",
        Button = "Button",
        ButtonDropdown = "ButtonDropdown",
        ButtonGroup = "ButtonGroup",
        ButtonToolbar = "ButtonToolbar",
        Card = "Card",
        CardBody = "CardBody",
        CardColumns = "CardColumns",
        CardDeck = "CardDeck",
        CardFooter = "CardFooter",
        CardGroup = "CardGroup",
        CardHeader = "CardHeader",
        CardImg = "CardImg",
        CardImgOverlay = "CardImgOverlay",
        CardLink = "CardLink",
        CardSubtitle = "CardSubtitle",
        CardText = "CardText",
        CardTitle = "CardTitle",
        Carousel = "Carousel",
        CarouselItem = "CarouselItem",
        CarouselControl = "CarouselControl",
        CarouselIndicators = "CarouselIndicators",
        CarouselCaption = "CarouselCaption",
        Col = "Col",
        Collapse = "Collapse",
        Container = "Container",
        CustomInput = "CustomInput",
        Dropdown = "Dropdown",
        DropdownItem = "DropdownItem",
        DropdownMenu = "DropdownMenu",
        DropdownToggle = "DropdownToggle",
        Fade = "Fade",
        Form = "Form",
        FormFeedback = "FormFeedback",
        FormGroup = "FormGroup",
        FormText = "FormText",
        Input = "Input",
        InputGroup = "InputGroup",
        InputGroupAddon = "InputGroupAddon",
        InputGroupButtonDropdown = "InputGroupButtonDropdown",
        InputGroupText = "InputGroupText",
        Jumbotron = "Jumbotron",
        Label = "Label",
        ListGroup = "ListGroup",
        ListGroupItem = "ListGroupItem",
        ListGroupItemHeading = "ListGroupItemHeading",
        ListGroupItemText = "ListGroupItemText",
        Media = "Media",
        Modal = "Modal",
        ModalBody = "ModalBody",
        ModalFooter = "ModalFooter",
        ModalHeader = "ModalHeader",
        Nav = "Nav",
        Navbar = "Navbar",
        NavbarBrand = "NavbarBrand",
        NavbarToggler = "NavbarToggler",
        NavItem = "NavbarToggler",
        NavLink = "NavLink",
        Pagination = "Pagination",
        PaginationItem = "PaginationItem",
        PaginationLink = "PaginationLink",
        Popover = "Popover",
        PopoverBody = "PopoverBody",
        PopoverHeader = "PopoverHeader",
        Progress = "Progress",
        Row = "Row",
        TabContent = "TabContent",
        Table = "Table",
        TabPane = "TabPane",
        tag = "Tag",
        Tooltip = "Tooltip",
        ul = "ul",
        li = "li",
        ol = "ol",
        a = "a",
        button = "button",
        br = "br",
        code = "code",
        div = "div",
        form = "form",
        header = "header",
        option = "option",
        select = "select",
        textarea = "textarea",
        table = "table",
        tbody = "tbody",
        td = "td",
        tfoot = "tfoot",
        th = "th",
        thead = "thead",
        span = "span",
        section = "section",
        script = "script",
        img = "img",
        input = "input",
        nav = "nav",
        p = "p",
        h1 = "h1",
        h2 = "h2",
        h3 = "h3",
        h4 = "h4",
        h5 = "h5",
        Article = "article",
        Aside = "aside";
    }

    public class B4Layout
    {
        public string LayoutName;
        public B4 Components = B4.Conainer();
        public B4Layout(string name) { LayoutName = name; }
    }

    public class Builder
    {
        public B4Layout create1()
        {
            B4Layout layout = new B4Layout("home");
            var r1 = B4.Row();
            string tt = "This could be the only web page dedicated to explaining the meaning of TMP (TMP acronym/abbreviation/slang word).Ever wondered what TMP means? Or any of the other 9127 slang words, abbreviations and acronyms listed here at Internet Slang? Your resource for web acronyms, web abbreviations and netspeak. ";
            r1.add(B4.Col(3).add(Ui.P(tt)))
                .add(B4.Col(9).add(Ui.P(tt))
                .add(B4.Button("Alert","danger", "alertx"))
                .add(B4.Button("Open Modal", "danger", "toggleModal", "exx"))  );
            layout.Components += r1;
            var modal_body = Ui.H1("hello to modal");
            var modal_buttons = Ui.Div().add(B4.Button("Ok", "primary", "toggleModal", "exx"), B4.Button("Cancel", "secondary", "toggleModal", "exx"));
            layout.Components += B4.Modal("exx", modal_body, "welcome modal", modal_buttons);
            return layout;
        }
        public B4Layout create2()
        {
            B4Layout layout = new B4Layout("home2");
            var r1 = B4.Row();
            var col1 = B4.Col(3).addTo(ref r1);
            var col2 = B4.Col(9).addTo(ref r1);
            var menu = B4.MenuListGroup(B4.MenuListItem("Home", "#"),
                B4.MenuListItem("Users", "#"),
                B4.MenuListItem("Products", "#"),
                B4.MenuListItem("Sales", "#"),
                B4.MenuListItem("Reports", "#"),
                B4.MenuListItem("Settings", "#"));
            col1.add(menu);
            col2.add(Ui.P("dasdasafsafasdfasdfsdajkfhs dsfhas kjhsdkf hsdkfha sdf hfkshfaksjfhsak sdkfhaskj fshdkajfh askfh "));
            col2.add(B4.Button("Click here ", "primary", "toggleModal", "exx2"));

            var modal_body = Ui.H1("hello to modal 2018").add(Ui.P("ddasdasdsad dasdkjashdasdas daskdjhasdsad asdkjshadasdsa dsadksajhdsa"));
            var modal_buttons = Ui.Div().add(B4.Button("Ok", "primary", "toggleModal", "exx2"), B4.Button("Cancel", "secondary", "toggleModal", "exx2"));
            layout.Components += r1;
            layout.Components += B4.Modal("exx2", modal_body, "welcome modal", modal_buttons);
            return layout;
        }
        public B4Layout create3()
        {
            B4Layout layout = new B4Layout("home3");
            var r1 = B4.Row().addTo(ref layout.Components);
            var col1 = B4.Col(3).addTo(ref r1);
            var col2 = B4.Col(9).addTo(ref r1);
           
            return layout;
        }
    }
}