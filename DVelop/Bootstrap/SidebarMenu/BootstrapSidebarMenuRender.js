﻿function BootstrapSidebarMenu(n) {
  function t(i, r) {
    var u = r.subItems;
    r.id = jQuery.trim(r.id);
    u instanceof Object && u.length > 0 ? n.each(u, function (n, i) {
      t(n, i)
    }) : r.subItems = []
  }

  function i() {
    n(".page-sidebar ul").each(function () {
      n(this).css("display", "block");
      var t = n(this).closest("li");
      t.addClass("open")
    })
  }
  this.SearchServiceUrl;
  this.SearchMinChars;
  this.SearchHelperDescription;
  this.SidebarMainClass;
  this.HeaderClass;
  this.SearchInputClass;
  this.SearchIconClass;
  this.SearchHelperClass;
  this.SearchResultClass;
  this.SidebarMenuClass;
  this.SidebarMenuOptionsData;
  this.SidebarMenuUserData;
  this.GAMOAuthToken;
  this.SelectedItem = 0;
  this.HasMenuSearch;
  this.ScrollWidth;
  this.AllMenuItemsVisibleAtLoad;
  this.ScrollAlwaysVisible = !1;
  this.HideScrollInCompactMenu = !0;
  this.FirstLevelIsGrouping = !1;
  this.ToggleButtonPosition;
  this.scrollTop = 0;
  this.needExecShow = !0;
  this.ResetSelectedOption = function () {
    this.setActiveItem(1);
    var n = this.getActiveItem();
    this.openItem(n)
  };
  this.SetSidebarMenuOptionsDataOptionsData = function (n) {
    n != undefined && n.length > 0 && (jQuery.each(n, function (n, i) {
      t(n, i)
    }), this.needExecShow || (this.SidebarMenuOptionsData == undefined || this.SidebarMenuOptionsData.length != n.length || JSON.stringify(this.SidebarMenuOptionsData, null, 2) != JSON.stringify(n, null, 2)) && (this.needExecShow = !0), this.SidebarMenuOptionsData = n)
  };
  this.GetSidebarMenuOptionsDataOptionsData = function () {
    return this.SidebarMenuOptionsData
  };
  this.SetSidebarMenuUserData = function (n) {
    n != undefined && (this.needExecShow || (this.SidebarMenuUserData == undefined || JSON.stringify(this.SidebarMenuUserData, null, 2) != JSON.stringify(n, null, 2)) && (this.needExecShow = !0), this.SidebarMenuUserData = n)
  };
  this.GetSidebarMenuUserData = function () {
    return this.SidebarMenuUserData
  };
  this._sidebarMenuClass;
  this.show = function () {
    var l, t, f, a, o, v, s, k, h, nt, c, y, r, p, u;
    if (this.HasMenuSearch = this.SearchServiceUrl && this.SearchServiceUrl != "", this.needExecShow || !this.IsPostBack || n(window).width() <= 767) try {
      this.needExecShow = !1;
      var w = this.getContainerControl(),
        it = w.id,
        rt = this.ContainerName,
        b = this.SidebarMainClass || "page-sidebar",
        e = this.HeaderClass || "sidebar-header-wrapper",
        d = this.SearchInputClass || "searchinput",
        g = this.SearchIconClass || "searchicon fa fa-search",
        ut = this.SearchHelperClass || "searchhelper",
        ft = this.SearchResultClass || "searchresult";
      this._sidebarMenuClass = this.SidebarMenuClass || "nav sidebar-menu";
      l = !1;
      readCookie("DVelopBootstrap_SidebarMenu_State") == "C" && (l = !0, b += " menu-compact");
      t = '<div class="' + b + '" id="sidebar">';
      t += '<div class="sidebar-header">';
      this.SidebarMenuUserData != null && this.SidebarMenuUserData != "" && (this.SidebarMenuUserData.PhotoUri != "" || this.SidebarMenuUserData.FirstLine != "" || this.SidebarMenuUserData.SecondLine != "") && (t += '<div class="' + e + ' user-info">', this.SidebarMenuUserData.PhotoUri != "" && (t += '<div><img src="' + this.SidebarMenuUserData.PhotoUri + '"><\/img><\/div>'), t += '<div class="user-text">', t += '<span class="user-info-first">' + this.SidebarMenuUserData.FirstLine + "<\/span><br>", t += '<span class="user-info-second">' + this.SidebarMenuUserData.SecondLine + " <\/span>", t += "<\/div>", t += "<\/div>");
      this.IncludeToggleButton && this.ToggleButtonPosition == "Top" && (t += '<div class="' + e + ' show-hide-menu"><i class="' + this.ToggleButtonClass + '"><\/i><\/div>');
      this.HasMenuSearch && (t += '<div class="' + e + '"><input type="text" id="sidebar_search_input" autocomplete="off" autocorrect="off" autocapitalize="off"  class="' + d + '" placeholder="' + gx.getMessage(this.SearchHelperDescription) + '" /><i class="' + g + '"><\/i><i class="searchreset fa-fw fa fa-times"><\/i>', t += "<\/div>");
      t += "<\/div>";
      t += '<ul id="sidebar_ul" class="' + this._sidebarMenuClass + '">';
      r = this;
      this.SidebarMenuOptionsData != undefined && this.SidebarMenuOptionsData.length > 0 && (f = !1, a = !0, jQuery.each(this.SidebarMenuOptionsData, function (i, u) {
        var e, o;
        r.FirstLevelIsGrouping ? (f && (t += '<li class="menuGroupTitleDivider"><\/li>'), e = u.subItems, e instanceof Object && e.length > 0 ? (f || a || (t += '<li class="menuGroupTitleDivider"><\/li>'), o = u.tooltip != null && u.tooltip.trim() != "" ? " title='" + WWP_replaceAll(u.tooltip, "'", "") + "'" : "", t += '<li class="menuGroupTitle"' + o + ">" + u.caption + "<\/li>", n.each(e, function (n, i) {
          t += "<li>" + r._sidebarMenuRecursiveLoad(n, i) + "<\/li>"
        }), f = !0) : (t += "<li>" + r._sidebarMenuRecursiveLoad(i, u) + "<\/li>", f = !1), a = !1) : t += "<li>" + r._sidebarMenuRecursiveLoad(i, u) + "<\/li>"
      }));
      t += "<\/ul>";
      this.IncludeToggleButton && this.ToggleButtonPosition == "Bottom" && (this.ToggleButtonClass = "fas fa-chevron-left", t += '<div class="sidebar-header ">', t += '<div class="' + e + ' show-hide-menu sidebar-header-bottom"><i class="' + this.ToggleButtonClass + '"><\/i><\/div>', t += "<\/div>");
      t += "<\/div>";
      w.innerHTML = t;
      this.ScrollWidth > 0 && n("#sidebar_ul > li").hover(function () {
        n(this).closest(".slimScrollDiv").addClass("liExpanded")
      }, function () {
        n(this).closest(".slimScrollDiv").removeClass("liExpanded")
      });
      jQuery(".sidebar-menu").on("click", function (t) {
        var i = n(t.target).closest("a");
        return r._clickHandler(i, t)
      });
      if (u = this.getActiveItem(), u && u != "" && this.openItem(u), this.HasMenuSearch) {
        jQuery("#sidebar_search_input").on("input", function () {
          if (this.value.length >= r.SearchMinChars) return r.onSearchExec(this.value);
          r.onSearchExec("")
        });
        n(n("#sidebar_search_input").get(0)).keydown(function (n) {
          if (n.keyCode == 13) return n.preventDefault(), !1
        });
        n(".page-sidebar .sidebar-header-wrapper .searchreset").on("click", function () {
          n("#sidebar_search_input").get(0).value = "";
          r.onSearchExec("")
        })
      }
      for (o = jQuery("div.page-container"), v = jQuery("div.page-sidebar"), o.length > 0 && v.length > 0 && (s = o.children().get(0), s && s.id != "sidebar" && (k = n(s), v.detach().prependTo(o), k.remove())), h = n("#sidebar_ul").get(0), nt = 0, c = 0; c < h.childNodes.length; c++) {
        y = h.childNodes[c];
        n(y).on("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function (t) {
          n(t).css("opacity") == "1" && (t.removeAttribute("ch"), n(t).css("height", ""))
        }(y))
      }
      if (n(".page-content").removeClass("hideMenu"), this.display(), n(".page-content").addClass("sidebarmenu-transtion"), n("#sidebar").addClass("sidebarmenu-transtion"), l && this.FirstLevelIsGrouping && n(h).find(".menuGroupTitle").css("display", "none"), this.AllMenuItemsVisibleAtLoad && i(), this.IncludeToggleButton) n(".page-sidebar .show-hide-menu").on("click", function () {
        r.CollapseExpand()
      });
      this.ScrollWidth > 0 && (r = this, n(window).resize(function () {
        if (r.HideScrollInCompactMenu) {
          var n = readCookie("DVelopBootstrap_SidebarMenu_State");
          n != "C" && r.updateSlimscroll(!1)
        } else r.updateSlimscroll(!1)
      }));
      gx.fx.obs.notify("dvelop.extuc.sidebar.init", null)
    } catch (tt) {
      gx.dbg.write(tt.toString())
    } else p = readCookie("DVelopBootstrap_SidebarMenuSelected") || 0, u = this.getActiveItem(), p != u && (this.setInactiveItem(p), this.setActiveItem(this.SelectedItem), u && u != "" && this.openItem(u), this.IsScrollVisible() && (this.scrollTop = -1, this.updateSlimscroll(!0)))
  };
  this.IsScrollVisible = function () {
    return this.ScrollWidth > 0 && (!n("#sidebar").hasClass("menu-compact") || !this.HideScrollInCompactMenu)
  };
  this.updateScrollBottomSpace = function () {
    var i = 0,
      f = this.getContainerControl(),
      t = n(f).find("div>ul.nav.sidebar-menu>li:last-child").get(0),
      r, u;
    t != null && (r = "", n("#sidebar").hasClass("menu-compact") && (u = n(t).find(">ul").get(0), u != null && (i = n(u).height(), i > parseInt(n(t).css("margin-bottom")) && (r = i))), n(t).css("transition", "margin-bottom 0.2s"), n(t).css("margin-bottom", r))
  };
  this._clickHandler = function (t, i) {
    if (t && t.length !== 0) {
        var isCompact = n("#sidebar").hasClass("menu-compact");
        if (!t.hasClass("menu-dropdown")) {
            if (isCompact && t.get(0).parentNode.parentNode == this) {
                var f = t.find(".menu-text").get(0);
                if (i && i.target != f && !n.contains(f, i.target)) return !1;
            }
            if (i) {
                this.onSelectedItemExec(i, t.get(0));
                if (navigator.userAgent.toLowerCase().indexOf("firefox") != -1 && n(i.target).closest("a").attr("href") == "#") return !1;
            }
            return;
        }
        var submenu = t.next(".submenu");
        var parentLi = t.parent("li");
        var isOpen = parentLi.hasClass("open");
        if (isOpen) {
            submenu.stop(true, true).slideUp(200, function () {
                parentLi.removeClass("open");
                submenu.css("display", "none");
            });
        } else {
            parentLi.siblings(".open").each(function () {
                n(this).removeClass("open").children(".submenu").stop(true, true).slideUp(200).css("display", "none");
            });
            submenu.stop(true, true).slideDown(200, function () {
                parentLi.addClass("open");
                submenu.css("display", "block");
            });
        }
        return false;
    }
};
  this._sidebarMenuRecursiveLoad = function (t, i) {
    var r, u, f;
    return _buffer = "", r = i.subItems, u = i.tooltip != null && i.tooltip.trim() != "" ? " title='" + WWP_replaceAll(i.tooltip, "'", "") + "'" : "", r instanceof Object && r.length > 0 ? (_buffer += '<a href="#" class="menu-dropdown"' + u + '><i class="' + i.iconClass + '"><\/i><span class="menu-text">' + i.caption + ' <\/span><i class="menu-expand"><\/i><\/a><ul class="submenu">', f = this, n.each(r, function (n, t) {
      _buffer += "<li>" + f._sidebarMenuRecursiveLoad(n, t) + "<\/li>"
    }), _buffer += "<\/ul>") : (_link = i.link || "#", _linkTarget = i.linkTarget || "", i.id = jQuery.trim(i.id), _activeClass = "", i.id === jQuery.trim(this.getActiveItem()) && (_activeClass = "active"), _buffer += '<li class="' + _activeClass + '"><a href="' + _link + '" id="' + i.id + '"', _link != "#" && (_buffer += ' target="' + _linkTarget + '"'), _buffer += u + ">", i.iconClass && i.iconClass != "" && (_buffer += '<i class="' + i.iconClass + '"><\/i>'), _buffer += '<span class="menu-text">' + i.caption + "<\/span><\/a><\/li>"), _buffer
  };
  this.onSelectedItemExec = function (t, i) {
    try {
      if (this.setInactiveItem(this.getActiveItem()), this.SelectedItem = i.id || 0, this.setActiveItem(this.SelectedItem), !n("#sidebar").hasClass("menu-compact")) {
        if (this.HasMenuSearch && n("#sidebar_search_input").get(0).value != "") {
          n("#sidebar_search_input").get(0).value = "";
          this.needExecShow = !0;
          this.show();
          return
        }
        var r = this.getActiveItem();
        r && r != "" && this.openItem(r)
      }
      if (this.IsScrollVisible() && (this.scrollTop = -1, this.updateSlimscroll(!0)), i && n(i).attr("href") != "#") return !1;
      this.OnSelectedItem()
    } catch (u) {
      gx.dbg.write(u.toString())
    }
    return !0
  };
  this.onSearchExec = function (t) {
    var f, e;
    try {
      var u = n("#sidebar_ul").get(0),
        h = readCookie("DVelopBootstrap_SidebarMenu_State"),
        o = !0,
        r = -1,
        s = !(t != null && t.length > 0);
      for (s || (t = t.normalize != null ? t.normalize("NFD").replace(/[\u0300-\u036f]/g, "") : t), f = 0; f < u.childNodes.length; f++) e = u.childNodes[f], e.childNodes.length > 0 && n(e).find("> a > span").length > 0 ? this.onSearchOptionMatches(e, t) && (r != -1 && (!o || n(u.childNodes[r]).hasClass("menuGroupTitle") ? n(u.childNodes[r]).slideDown(200) : n(u.childNodes[r]).slideUp(200), this.LiIsGroupTitle(u, r + 1) && n(u.childNodes[r + 1]).slideDown(200), r = -1), o = !1) : this.LiIsGroupTitle(u, f) && (s ? h == "C" && n(e).hasClass("menuGroupTitle") ? n(e).slideUp(200) : n(e).slideDown(200) : (r != -1 && (n(u.childNodes[r]).slideUp(200), this.LiIsGroupTitle(u, r + 1) && n(u.childNodes[r + 1]).slideUp(200)), r = f, this.LiIsGroupTitle(u, f + 1) && f++));
      r != -1 && (n(u.childNodes[r]).slideUp(200), this.LiIsGroupTitle(u, r + 1) && n(u.childNodes[r + 1]).slideUp(200));
      this.AllMenuItemsVisibleAtLoad && i()
    } catch (c) {
      gx.dbg.write(c.toString())
    }
    return !0
  };
  this.LiIsGroupTitle = function (t, i) {
    return i < t.childNodes.length && (n(t.childNodes[i]).hasClass("menuGroupTitleDivider") || n(t.childNodes[i]).hasClass("menuGroupTitle"))
  };
  this.onSearchOptionMatches = function (t, i) {
    var r = t.getElementsByTagName("a")[0],
      o = r.getElementsByTagName("span")[0],
      u = n(o).text(),
      e, s, f;
    if (i != null && i.length > 0) {
      if (e = (u.normalize != null ? u.normalize("NFD").replace(/[\u0300-\u036f]/g, "") : u).toLowerCase().indexOf(i.toLowerCase()), e >= 0) {
        if (u = u.substring(0, e) + "<strong>" + u.substring(e, e + i.length) + "<\/strong>" + u.substring(e + i.length), s = o.getAttribute("dscSuffix"), o.innerHTML = s != null ? u + s : u, this.onSearchSubMenuOptionMatches(r, i)) n(t).hasClass("open") || (f = r.parentNode.getElementsByTagName("ul")[0], n(f).slideDown(200), n(t).addClass("open"), n(t).slideDown(200));
        else if (n(r).hasClass("menu-dropdown")) {
          n(t).removeClass("open");
          this.onSearchSubMenuOptionMatches(r, "");
          f = r.parentNode.getElementsByTagName("ul")[0];
          n(f).slideUp(200)
        }
        return n(t).slideDown(200), !0
      }
      return o.innerHTML = u, this.onSearchSubMenuOptionMatches(r, i) ? (f = r.parentNode.getElementsByTagName("ul")[0], n(f).slideDown(200), n(t).addClass("open"), n(t).slideDown(200), !0) : (n(t).slideUp(200), !1)
    }
    if (o.innerHTML = u, n(t).slideDown(200), n(r).hasClass("menu-dropdown")) {
      n(t).removeClass("open");
      f = r.parentNode.getElementsByTagName("ul")[0];
      n(f).slideUp(200);
      this.onSearchSubMenuOptionMatches(r, i)
    }
    return !0
  };
  this.onSearchSubMenuOptionMatches = function (t, i) {
    var e = !1,
      u, r, f;
    if (n(t).hasClass("menu-dropdown"))
      for (u = t.parentNode.getElementsByTagName("ul")[0], r = 0; r < u.childNodes.length; r++) f = u.childNodes[r], f.childNodes.length > 0 && this.onSearchOptionMatches(f, i) && (e = !0);
    return e
  };
  this.getActiveItem = function () {
    if (this.getActiveItem_loaded == window.location.href) {
      var n = readCookie("DVelopBootstrap_SidebarMenuSelected") || 0;
      return this.SelectedItem = n, n
    }
    return this.getActiveItem_loaded = window.location.href, this.SidebarMenuOptionsData != undefined && this.SidebarMenuOptionsData.length > 0 && this.findActiveItemByUrlRecursive(this.SidebarMenuOptionsData), this.getActiveItem()
  };
  this.findActiveItemByUrlRecursive = function (n) {
    var t = this;
    jQuery.each(n, function (n, i) {
      var u = i.subItems,
        r;
      if (u instanceof Object && u.length > 0) t.findActiveItemByUrlRecursive(u);
      else if (i != null && i.link != null && (r = i.link.split(" ").join("%20"), r.indexOf("/") == -1 && (r = "/" + r), window.location.href.length >= r.length && window.location.href.substring(window.location.href.length - r.length, window.location.href.length).toLowerCase() == r.toLowerCase())) return createCookie("DVelopBootstrap_SidebarMenuSelected", i.id), !1
    })
  };
  this.setActiveItem = function (t) {
    var i = n(".page-sidebar a[id='" + jQuery.trim(t) + "']");
    i && i.length > 0 && (createCookie("DVelopBootstrap_SidebarMenuSelected", t), i.closest("li").addClass("active"))
  };
  this.setInactiveItem = function (t) {
    var $sidebar = n(".page-sidebar");
    $sidebar.find("li.open").removeClass("open");
    $sidebar.find("ul.submenu").css("display", "none");
    $sidebar.find("li.active").removeClass("active");
    var $prev = $sidebar.find("a[id='" + jQuery.trim(t) + "']");
    if ($prev && $prev.length > 0) {
      $prev.closest("li").removeClass("active");
      createCookie("DVelopBootstrap_SidebarMenuSelected", "");
    }
  };
  this.openItem = function (t) {
    var i, r, u;
    t && t != "" && (i = n(".page-sidebar a[id='" + jQuery.trim(t) + "']"), r = n("#sidebar").hasClass("menu-compact"), !r && i && i.length == 1 && (u = i.parents("ul"), n.each(u, function (t, i) {
      if (i = n(i), i.hasClass("submenu")) {
        var r = i.closest("li");
        r.addClass("open");
        i = i.closest("ul")
      } else if (i.hasClass("sidebar-menu")) return !1
    })), this.IsScrollVisible() && (this.scrollTop = -1))
  };
  this.getA_scrollTop = function (t) {
    var i = n(".page-sidebar a[id='" + jQuery.trim(t) + "']"),
      r, u, f;
    return i.length > 0 ? (r = n(window).height() - n(".sidebar-menu").offset().top + n(window).scrollTop(), i.is(":visible"), u = i.offset().top, u != 0 && i.is(":visible") ? (f = n(".sidebar-menu").scrollTop() + u - n(".sidebar-menu").offset().top, f + i[0].scrollHeight + 10 <= r ? 0 : f - (r - i[0].scrollHeight) / 2) : 0) : 0
  };
  this.display = function () {
    n(window).width() <= 500 && (n("#sidebar").addClass("hide"), n(".page-content").addClass("hideMenu"), n(".page-content").addClass("menu-compact"), n(".sidebar-toggler").toggleClass("active"), createCookie("DVelopBootstrap_SidebarMenu_State", "C"));
    var t = readCookie("DVelopBootstrap_SidebarMenu_State");
    t == "C" ? this.CollapseAux(!0) : t == "H" ? this.hide() : this.ExpandAux(!0)
  };
  this.Expand = function () {
    this.ExpandAux(!1)
  };
  this.ExpandAux = function (t) {
    var u, r, i;
    if (createCookie("DVelopBootstrap_SidebarMenu_State", "E"), !t && this.FirstLevelIsGrouping) this.onSearchExec("");
    n(".page-content").removeClass("hideMenu");
    u = n("#sidebar").hasClass("menu-compact");
    n("#sidebar").is(":visible") || n("#sidebar").removeClass("hide");
    n(".sidebar-collapse").removeClass("active");
    n(".sidebar-toggler").removeClass("active");
    n(".page-content").removeClass("menu-compact");
    n(".page-sidebar").removeClass("menu-compact");
    this.ScrollWidth > 0 && (this.updateScrollBottomSpace(), this.updateSlimscroll(!0));
    var f = n(".page-content").css("transition-duration") != "0s, 0s, 0s",
      e = n("table.GridWithTotalizer").length,
      o = n("table.GridWithPaginationBar").length;
    if (f) {
      typeof ClearMinWidthPaginationBars == "function" && ClearMinWidthPaginationBars();
      n(".gx-grid>table.TitleFixed>thead").css("max-width", "calc(100% - 50px)");
      n(".gx-grid>table.TitleFixed>tfoot").css("max-width", "calc(100% - 50px)");
      r = this;
      this.resizeTriggered = !1;
      n(".page-content").one("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {
        n(".gx-grid>table.TitleFixed>thead").css("max-width", "");
        n(".gx-grid>table.TitleFixed>tfoot").css("max-width", "");
        r.resizeTriggered || r.triggerResize()
      })
    } else this.triggerResize();
    t || (i = this.getActiveItem(), i && i != "" && this.openItem(i), this.scrollTop = -1)
  };
  this.CollapseExpand = function () {
    var n = readCookie("DVelopBootstrap_SidebarMenu_State");
    n == "C" ? this.Expand() : n == "E" && this.Collapse()
  };
  this.Collapse = function () {
    this.CollapseAux(!1)
  };
  this.CollapseAux = function (t) {
    var r, i, f, u;
    if (createCookie("DVelopBootstrap_SidebarMenu_State", "C"), this.HasMenuSearch && (n("#sidebar_search_input").get(0).value = ""), !t && this.FirstLevelIsGrouping) this.onSearchExec("");
    if (r = n("#sidebar").hasClass("menu-compact"), n("#sidebar").is(":visible") || n("#sidebar").addClass("hide"), n("#sidebar").addClass("menu-compact"), n(".sidebar-collapse").toggleClass("active"), r = n("#sidebar").hasClass("menu-compact"), n(".page-content").addClass("menu-compact"), this.ScrollWidth > 0 && (this.updateScrollBottomSpace(), this.HideScrollInCompactMenu ? this.removeSlimscroll() : this.updateSlimscroll(!0)), r && n(".open > .submenu").removeClass("open"), t || (i = this.getActiveItem(), i && i != "" && this.openItem(i)), f = n(".page-content").css("transition-duration") != "0s, 0s, 0s", f) {
      u = this;
      this.resizeTriggered = !1;
      n(".page-content").one("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {
        u.resizeTriggered || u.triggerResize()
      })
    } else this.triggerResize()
  };
  this.triggerResize = function () {
    this.resizeTriggered = !0;
    try {
      gx.evt.dispatch(window, new Event("resize"))
    } catch (t) {
      var n = window.document.createEvent("UIEvents");
      n.initUIEvent("resize", !0, !1, window, 0);
      window.dispatchEvent(n)
    }
  };
  this.updateSlimscroll = function (n) {
    this.timeoutSlimscroll != null && clearTimeout(this.timeoutSlimscroll);
    var t = this;
    this.timeoutSlimscroll = setTimeout(function () {
      t.createSlimscroll(n)
    }, 400)
  };
  this.removeSlimscroll = function () {
    var t = n(".sidebar-menu");
    t.closest("div").hasClass("slimScrollDiv") && (t.slimScroll({
      destroy: !0
    }), t.attr("style", ""), t.parent().find(">.slimScrollRail").remove(), t.parent().find(">.slimScrollBar").remove())
  };
  this.createSlimscroll = function (t) {
    var r = this,
      i = n(".sidebar-menu"),
      s, u, f, e, h, o;
    if (i.length > 0) {
      s = 0;
      this.IncludeToggleButton && this.ToggleButtonPosition == "Bottom" && (u = n(".sidebar-header-wrapper.show-hide-menu"), u.length == 1 && (s = u.outerHeight() + parseInt(u.css("margin-top")) + parseInt(u.css("margin-bottom"))));
      f = n(window).height() - i.offset().top + n(window).scrollTop() - s;
      i.closest("div").hasClass("slimScrollDiv") ? (i.height(f - parseInt(i.css("padding-bottom"))), n(".slimScrollDiv").height(f)) : (e = i.parent().position(), h = e != null && e.left != null && e.left > window.innerWidth / 2 ? "right" : "left", i.slimscroll({
        height: f,
        position: h,
        size: r.ScrollWidth + "px",
        alwaysVisible: r.ScrollAlwaysVisible
      }));
      a = i.get(0);
      a.style.setProperty("overflow", "hidden", "important");
      i.slimScroll().on("slimscrolling", function () {
        r.scrollTop = i.scrollTop()
      });
      i.trigger("mouseenter");
      r.scrollTop == -1 && (r.scrollTop = 0, o = r.getActiveItem(), o && o != "" && (r.scrollTop = r.getA_scrollTop(o)));
      r.scrollContent(r.scrollTop, t)
    }
  };
  this.scrollContent = function (t, i) {
    var f = t,
      r = n(".sidebar-menu"),
      e = n(".slimScrollBar"),
      s = r.outerHeight() - e.outerHeight(),
      u = f / r[0].scrollHeight * r.outerHeight(),
      o;
    u = Math.min(Math.max(u, 0), s) + "px";
    i ? (e.animate({
      top: u
    }, 200), o = this, r.animate({
      scrollTop: f
    }, 200, "swing", function () {
      o.scrollTop = n(".sidebar-menu").scrollTop()
    })) : (e.css({
      top: u
    }), r.scrollTop(f))
  };
  this.hide = function () {
    createCookie("DVelopBootstrap_SidebarMenu_State", "H");
    n("#sidebar").addClass("hide");
    n(".sidebar-toggler").addClass("active");
    n(".page-content").addClass("hideMenu")
  };
  var r = this;
  n(window).on("load", function () {
    n(".sidebar-toggler").on("click", function () {
      var t = n("#sidebar").hasClass("hide");
      return t ? r.Expand() : r.hide(), !1
    })
  })
};
$(window).one('load', function () {
  WWP_VV([
    ['GXBootstrap.SidebarMenu', '15.2.9']
  ]);
});