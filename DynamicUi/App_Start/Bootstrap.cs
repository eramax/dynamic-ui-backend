using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DynamicUi
{
    public class Bootstrap
    {
        public BC b1 { get; set; }
        [JsonConverter(typeof(JsonPropertyAttribute))]
        public BC b2 { get; set; }
        public Bootstrap()
        {
            b1 = BC.table_bordered;
            b2 = BC.alert;
        }
        
    }
    public class BSComponent {
        public Bs ComponentType { get; set; }
        public BSComOptions Options { get; set; }
    }
    public class BSComOptions
    {
        public List<BC> ComponentClasses { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string id { get; set; }

        public string For { get; set; }
        public string multiple { get; set; }
        public string disabled { get; set; }
        public string tabindex { get; set; }
        public string role { get; set; }
        public string data_dismiss { get; set; }
        public string aria_label { get; set; }
        public string aria_hidden { get; set; }
        public string row { get; set; }
        public string check { get; set; }
        public string xs { get; set; }
        public string sm { get; set; }
        public string md { get; set; }
        public string form { get; set; }
        public string inline { get; set; }
        public string valid { get; set; }
        public string invalid { get; set; }
        public string tooltip { get; set; }
        public string plaintext { get; set; }
        public string placeholder { get; set; }
        public string color { get; set; }
        public string bsSize { get; set; }
        public string hidden { get; set; }
        public string label { get; set; }
    }

    public enum Bs
    {
        Alert,
        Badge,
        Breadcrumb,
        BreadcrumbItem,
        Button,
        ButtonDropdown,
        ButtonGroup,
        ButtonToolbar,
        Card,
        CardBody,
        CardColumns,
        CardDeck,
        CardFooter,
        CardGroup,
        CardHeader,
        CardImg,
        CardImgOverlay,
        CardLink,
        CardSubtitle,
        CardText,
        CardTitle,
        Carousel,
        CarouselItem,
        CarouselControl,
        CarouselIndicators,
        CarouselCaption,
        Col,
        Collapse,
        Container,
        CustomInput,
        Dropdown,
        DropdownItem,
        DropdownMenu,
        DropdownToggle,
        Fade,
        Form,
        FormFeedback,
        FormGroup,
        FormText,
        Input,
        InputGroup,
        InputGroupAddon,
        InputGroupButtonDropdown,
        InputGroupText,
        Jumbotron,
        Label,
        ListGroup,
        ListGroupItem,
        ListGroupItemHeading,
        ListGroupItemText,
        Media,
        Modal,
        ModalBody,
        ModalFooter,
        ModalHeader,
        Nav,
        Navbar,
        NavbarBrand,
        NavbarToggler,
        NavItem,
        NavLink,
        Pagination,
        PaginationItem,
        PaginationLink,
        Popover,
        PopoverBody,
        PopoverHeader,
        Progress,
        Row,
        TabContent,
        Table,
        TabPane,
        Tag,
        Tooltip,
    }

    public enum BC
    {
        active
        , alert
        , alert_danger
        , alert_dark
        , alert_dismissible
        , alert_heading
        , alert_info
        , alert_light
        , alert_link
        , alert_primary
        , alert_secondary
        , alert_success
        , alert_warning
        , align_baseline
        , align_bottom
        , align_middle
        , align_top
        , align_text_top
        , align_text_bottom
        , align_content_around
        , align_content____around
        , align_content_center
        , align_content____center
        , align_content_end
        , align_content____end
        , align_content_start
        , align_content____start
        , align_content_stretch
        , align_content____stretch
        , align_items_start
        , align_items____start
        , align_items_end
        , align_items____end
        , align_items_center
        , align_items____center
        , align_items_baseline
        , align_items____baseline
        , align_items_stretch
        , align_items____stretch
        , align_self_start
        , align_self____start
        , align_self_end
        , align_self____end
        , align_self_center
        , align_self____center
        , align_self_baseline
        , align_self_stretch
        , align_self____stretch
        , badge
        , badge_danger
        , badge_dark
        , badge_info
        , badge_light
        , badge_pill
        , badge_primary
        , badge_secondary
        , badge_success
        , badge_warning
        , bg_danger
        , bg_dark
        , bg_info
        , bg_light
        , bg_primary
        , bg_secondary
        , bg_success
        , bg_warning
        , blockquote
        , blockquote_footer
        , border
        , border_bottom_0
        , border_danger
        , border_dark
        , border_info
        , border_left_0
        , border_light
        , border_primary
        , border_right_0
        , border_top_0
        , border_secondary
        , border_success
        , border_warning
        , border_white
        , border_0
        , breadcrumb
        , breadcrumb_item
        , btn
        , btn_block
        , btn_dark
        , btn_danger
        , btn_group
        , btn_group_lg
        , btn_group_sm
        , btn_group_vertical
        , btn_info
        , btn_light
        , btn_link
        , btn_lg
        , btn_outline_dark
        , btn_outline_danger
        , btn_outline_info
        , btn_outline_light
        , btn_outline_primary
        , btn_outline_secondary
        , btn_outline_success
        , btn_outline_warning
        , btn_primary
        , btn_sm
        , btn_secondary
        , btn_success
        , btn_toolbar
        , btn_warning
        , card
        , card_body
        , card_columns
        , card_danger
        , card_dark
        , card_deck
        , card_footer
        , card_group
        , card_header
        , card_header_tabs
        , card_header_pills
        , card_img_bottom
        , card_img_overlay
        , card_img_top
        , card_info
        , card_light
        , card_link
        , card_primary
        , card_secondary
        , card_subtitle
        , card_success
        , card_text
        , card_title
        , card_warning
        , carousel
        , carousel_caption
        , carousel_control_next
        , carousel_control_next_icon
        , carousel_control_prev
        , carousel_control_prev_icon
        , carousel_indicators
        , carousel_inner
        , carousel_item
        , clearfix
        , close
        , col___
        , col_sm___
        , col_md___
        , col_lg___
        , col_xl___
        , collapse
        , show
        , container
        , container_fluid
        , custom_checkbox
        , custom_control
        , custom_control_input
        , custom_control_inline
        , custom_control_label
        , custom_file
        , custom_radio
        , custom_range
        , custom_select
        , custom_select_lg
        , custom_select_sm
        , disabled
        , dropdown
        , dropdown_divider
        , dropdown_header
        , dropdown_item
        , dropdown_item_text
        , dropdown_menu
        , dropdown_menu_right
        , dropdown_toggle
        , dropleft
        , dropright
        , dropup
        , d_block
        , d____block
        , d_flex
        , d____flex
        , d_inline_flex
        , d____inline_flex
        , embed_responsive
        , embed_responsive_16by9
        , embed_responsive_4by3
        , embed_responsive_item
        , fade
        , fixed_bottom
        , fixed_top
        , flex_column
        , flex____column
        , flex_column_reverse
        , flex____column_reverse
        , flex_fill
        , flex____fill
        , flex_grow_0
        , flex_nowrap
        , flex____nowrap
        , flex_shrink_0
        , flex_row
        , flex____row
        , flex_row_reverse
        , flex____row_reverse
        , flex_wrap
        , flex____wrap
        , flex_wrap_reverse
        , flex____wrap_reverse
        , float_left
        , float____left
        , float_none
        , float_right
        , float____right
        , font_weight_bold
        , font_weight_italic
        , font_weight_light
        , font_weight_normal
        , form_check
        , form_check_inline
        , form_check_input
        , form_check_label
        , form_control
        , form_control_file
        , form_control_lg
        , form_control_plaintext
        , form_control_range
        , form_control_sm
        , form_group
        , form_inline
        , h_25
        , h_50
        , h_75
        , h_100
        , img_fluid
        , img_thumbnail
        , initialism
        , input_group
        , input_group_append
        , input_group_lg
        , input_group_prepend
        , input_group_sm
        , input_group_text
        , input_lg
        , input_sm
        , invisible
        , jumbotron
        , jumbotron_fluid
        , justify_content___
        , justify_content____around
        , justify_content____between
        , justify_content____center
        , justify_content____end
        , justify_content____start
        , lead
        , list_group
        , list_group_flush
        , list_group_item
        , list_group_item_action
        , list_group_item_danger
        , list_group_item_dark
        , list_group_item_info
        , list_group_item_light
        , list_group_item_primary
        , list_group_item_success
        , list_group_item_warning
        , list_inline
        , list_inline_item
        , list_unstyled
        , mark
        , media
        , media_body
        , modal
        , modal_body
        , modal_content
        , modal_dialog_centered
        , modal_footer
        , modal_header
        , modal_lg
        , modal_sm
        , m___
        , mt___
        , mb___
        , ml___
        , mr___
        , mx___
        , my___
        , mx_auto
        , nav
        , nav_tabs
        , nav_pills
        , nav_justified
        , navbar
        , navbar_nav
        , navbar_brand
        , navbar_collapse
        , navbar_expand___
        , navbar_dark
        , navbar_light
        , navbar_text
        , navbar_toggler
        , navlink
        , nav_item
        , no_gutters
        , page_item
        , page_link
        , pagination
        , pagination_lg
        , pagination_sm
        , pre_scrollable
        , progress
        , progress_bar
        , progress_bar_animated
        , progress_bar_striped
        , p___
        , pt___
        , pb___
        , pl___
        , pr___
        , py___
        , px___
        , rounded
        , rounded_bottom
        , rounded_circle
        , rounded_left
        , rounded_right
        , rounded_top
        , rounded_0
        , row
        , shadow
        , shadow_lg
        , shadow_md
        , shadow_none
        , shadow_sm
        , small
        , sr_only
        , sr_only_focusable
        , sticky_top
        , tab_content
        , tab_pane
        , table
        , table_active
        , table_bordered
        , table_borderless
        , table_condensed
        , table_dark
        , table_hover
        , table_responsive___
        , table_striped
        , text_capitalize
        , text_center
        , text____center
        , text_danger
        , text_dark
        , text_hide
        , text_info
        , text_light
        , text_justify
        , text_left
        , text____left
        , text_lowercase
        , text_muted
        , text_nowrap
        , text_primary
        , text_secondary
        , text_right
        , text____right
        , text_success
        , text_uppercase
        , text_warning
        , text_white
        , thead_dark
        , thead_light
        , visible
        , w_25
        , w_50
        , w_75
        , w_100
    }
}