using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace DynamicUi.dddd
{
    public class Bootstrap
    {
        public Layout buildBS1()
        {
            Layout layout = new Layout("home-layout");
            layout.Components.add(BB.ctg(BB.Tag.Row)
                       .add(BB.ctg(BB.Tag.Col)
                         .add(BB.ctg(BB.Tag.Alert, null, "This is a primary alert — check it out!", BB.S("color", BB.CR.danger))))
                       .add(BB.ctg(BB.Tag.Col).add(BB.ctg(BB.Tag.Button,"bt", " click here " ,BB.S(BB.OP.Class,BB.CR.primary)))));
                
            return layout;
        }
        public Layout buildBS2()
        {
            Layout layout = new Layout("home-layout");
            var r1 = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "row grow w-100"));
            var r2 = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "row w-100"));

            r1.add(BB.ctg(BB.Tag.div, null, "Header", BB.S(BB.OP.Class, "col-12 bg-primary py-3")));
            r1.add(BB.ctg(BB.Tag.div, null, "Menu", BB.S(BB.OP.Class, "col-4 bg-info py-3")));
            var dv1 = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "main col-8 bg-warning h-100 py-3"));
            dv1.add(BB.ctg(BB.Tag.h1, null, "Main"));
            dv1.add(BB.ctg(BB.Tag.p, null, "adadasdadadadadadsf fdsfas sdfsd sf fasfsafsdafsa sfsafas fsadfasd fsadfas f ", BB.S(BB.OP.Class, "mb -5")));
            dv1.add(BB.ctg(BB.Tag.button, null, "LoadModal", BB.S(BB.OP.Class, "btn btn-primary"), BB.S(BB.OP.OnClick, "alert")));
            r1.add(dv1);
            layout.Components.add(r1);

            r2.add(BB.ctg(BB.Tag.div, null, "Footer", BB.S(BB.OP.Class, "col-12 py-3 bg-danger")));
            layout.Components.add(r2);
            return layout;
        }
        public Layout buildBS3()
        {
            Layout layout = new Layout("home-layout");

            var modal_body = BB.ctg(BB.Tag.h1, null, "MooooDaaaal");
            var modal = BC.Model("exampleModal", "Welcome Modal", modal_body);
            layout.Components.add(modal);

            var r1 = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "row grow w-100"));
            var r2 = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "row w-100"));

            r1.add(BB.ctg(BB.Tag.div, null, "Header", BB.S(BB.OP.Class, "col-12 bg-primary py-3")));
            r1.add(BB.ctg(BB.Tag.div, null, "Menu", BB.S(BB.OP.Class, "col-4 bg-info py-3")));
            var dv1 = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "main col-8 bg-warning h-100 py-3"));
            dv1.add(BB.ctg(BB.Tag.h1, null, "Main"));
            dv1.add(BB.ctg(BB.Tag.p, null, "adadasdadadadadadsf fdsfas sdfsd sf fasfsafsdafsa sfsafas fsadfasd fsadfas f ", BB.S(BB.OP.Class, "mb -5")));
            dv1.add(BB.ctg(BB.Tag.button, null, "Alert", BB.S(BB.OP.Class, "btn btn-primary"), BB.S(BB.OP.OnClick, "alert")));
            dv1.add(BB.ctg(BB.Tag.button, null, "Load Modal Now", BB.S(BB.OP.Class, "btn btn-primary"), BB.S(BB.OP.data_toggle, "modal"), BB.S(BB.OP.data_target, "#exampleModal")));
            r1.add(dv1);
            layout.Components.add(r1);

            r2.add(BB.ctg(BB.Tag.div, null, "Footer", BB.S(BB.OP.Class, "col-12 py-3 bg-danger")));
            layout.Components.add(r2);           
            return layout;
        }
    }

    public class Layout
    {
        public string LayoutName;
        public BSComponent Components = new BSComponent(BB.Tag.Container, "con");
        public Layout(string name) { LayoutName = name; }
    }
    
    public class BSComponent
    {
        public string Type;
        public string id;
        public string Content;
        public Dictionary<string, string> Props = new Dictionary<string, string>();
        public List<BSComponent> Childerns = new List<BSComponent>();
        public BSComponent(string _type , string _id = null, string _content =null, params Dictionary<string,string>[] _props)
        {
            Type = _type;
            id = _id;
            Content = _content;
            foreach (var list in _props)
                foreach (var pr in list)
                    Props.Add(pr.Key, pr.Value);
        }
        public static BSComponent operator +(BSComponent left, BSComponent right)
        {
            left.Childerns.Add(right);
            return left;
        }
        public BSComponent add(params BSComponent[] t)
        {
            Childerns.AddRange(t);
            return this;
        }
    }

    public static class BC
    {
        public static BSComponent Model(string name,string title , BSComponent body)
        {
            var m1 = BB.ctg(BB.Tag.div, name, null, BB.S(BB.OP.tabindex, "-1"),
                BB.S(BB.OP.role, "dialog"),
                BB.S(BB.OP.aria_labelledby, name + "LB"),
                BB.S(BB.OP.aria_label))
                .add(BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "modal-dialog"), BB.S(BB.OP.role, "document")))
                .add(BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "modal-content")));
            var head = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "modal-header"));
            head.add(BB.ctg(BB.Tag.h5, name + "LB", title, BB.S(BB.OP.Class, "modal-title")));
            head.add(BB.ctg(BB.Tag.button, null, null, BB.S(BB.OP.Class, "close"), BB.S(BB.OP.data_dismiss, "modal"), BB.S(BB.OP.aria_label, "Close")))
                .add(BB.ctg(BB.Tag.span, null, "X", BB.S(BB.OP.aria_hidden)));
            m1.add(head);
            m1.add(body);
            var foot = BB.ctg(BB.Tag.div, null, null, BB.S(BB.OP.Class, "modal-footer"));
            foot += BB.ctg(BB.Tag.button, null, "Close", BB.S(BB.OP.Class, "btn btn-secondary"), BB.S(BB.OP.data_dismiss, "modal"));
            foot += BB.ctg(BB.Tag.button, null, "Save changes", BB.S(BB.OP.Class, "btn btn-primary"));
            m1.add(foot);
            return m1;
        }
    }

    public static class BB
    {
        public static BSComponent ctg(string _type, string _id = null,string content = null, params Dictionary<string, string>[] _props)
        {
            return new BSComponent(_type, _id, content, _props);
        }
        public class OP
        {
            public const string
                Class = "className",
                type = "type",
                name = "name",
                For = "for",
                tabindex = "tabIndex",
                role = "role",
                check = "check",
                xs = "xs",
                sm = "sm",
                md = "md",
                placeholder = "placeholder",
                bsSize = "bsSize",
                label = "label",
                href = "href",
                color = "color",
                data_toggle = "data-toggle",
                data_target = "data-target",
                aria_labelledby = "aria-labelledby",
                aria_hidden="aria-hidden",
                data_dismiss = "data-dismiss",
                aria_label = "aria-label",

                form = "form",
                inline = "inline",
                valid = "valid",
                invalid = "invalid",
                tooltip = "tooltip",
                plaintext = "plaintext",
                hidden = "hidden",
                row = "row",
                multiple = "multiple",
                disabled = "disabled",

                isOpen = "isOpen",
                toggle = "toggle",
                OnClick = "ClickAction",
                OnChange = "ChangeAction";

        }
        public class CL
        {
            public const string
                active = "active",
                alert = "alert",
                alert_link = "alert-link",
                alert_heading = "alert-heading",
                mb_0 = "mb-0";
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
            h5 = "h5";
        }
        public class CR
        {
            public const string
            primary = "primary",
            secondary = "secondary",
            success = "success",
            danger = "danger",
            warning = "warning",
            info = "info",
            light = "light",
            dark = "dark";
        }
        public static Dictionary<string, string> S(string type, params string[] arr)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            string tmp = "";
            if (arr == null || arr.Length == 0) tmp = "true";
            else 
            {
                tmp = String.Join(" ", arr);
            }
            list.Add(type, tmp);
            return list;
        }
    }
}