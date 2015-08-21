window.VTC = {
    "ditu": {
        "normal": {
            "version": "087",
            "updateDate": "20150815"
        },
        "satellite": {
            "version": "009",
            "updateDate": "20150601"
        },
        "normalTraffic": {
            "version": "081",
            "updateDate": "20150815"
        },
        "satelliteTraffic": {
            "version": "083",
            "updateDate": "20150815"
        },
        "mapJS": {
            "version": "104",
            "updateDate": "20150815"
        },
        "satelliteStreet": {
            "version": "083",
            "updateDate": "20150815"
        },
        "panoClick": {
            "version": "1033",
            "updateDate": "201400823"
        },
        "panoUdt": {
            "version": "20150815",
            "updateDate": "20150814"
        },
        "panoSwfAPI": {
            "version": "20150123",
            "updateDate": "20150123"
        },
        "panoSwfPlace": {
            "version": "20141112",
            "updateDate": "20141112"
        }
    },
    "webapp": {
        "high_normal": {
            "version": "001",
            "updateDate": "20141209"
        },
        "lower_normal": {
            "version": "002",
            "updateDate": "20150529"
        }
    },
    "api_for_mobile": {
        "vector": {
            "version": "002",
            "updateDate": "20150529"
        },
        "vectorIcon": {
            "version": "002",
            "updateDate": "20150529"
        }
    }
};
window.BMAP_AUTHENTIC_KEY = ""; (function () {
    var bU, a1 = bU = a1 || {
        version: "1.3.4"
    };
    a1.guid = "$BAIDU$";
    window[a1.guid] = window[a1.guid] || {};
    a1.object = a1.object || {};
    a1.extend = a1.object.extend = function (cD, T) {
        for (var cC in T) {
            if (T.hasOwnProperty(cC)) {
                cD[cC] = T[cC]
            }
        }
        return cD
    };
    a1.dom = a1.dom || {};
    a1.dom.g = function (T) {
        if ("string" == typeof T || T instanceof String) {
            return document.getElementById(T)
        } else {
            if (T && T.nodeName && (T.nodeType == 1 || T.nodeType == 9)) {
                return T
            }
        }
        return null
    };
    a1.g = a1.G = a1.dom.g;
    a1.dom.hide = function (T) {
        T = a1.dom.g(T);
        T.style.display = "none";
        return T
    };
    a1.hide = a1.dom.hide;
    a1.lang = a1.lang || {};
    a1.lang.isString = function (T) {
        return "[object String]" == Object.prototype.toString.call(T)
    };
    a1.isString = a1.lang.isString;
    a1.dom._g = function (T) {
        if (a1.lang.isString(T)) {
            return document.getElementById(T)
        }
        return T
    };
    a1._g = a1.dom._g;
    a1.dom.contains = function (T, cC) {
        var cD = a1.dom._g;
        T = cD(T);
        cC = cD(cC);
        return T.contains ? T != cC && T.contains(cC) : !!(T.compareDocumentPosition(cC) & 16)
    };
    a1.browser = a1.browser || {};
    if (/msie (\d+\.\d)/i.test(navigator.userAgent)) {
        a1.browser.ie = a1.ie = document.documentMode || +RegExp["\x241"]
    }
    a1.dom._NAME_ATTRS = (function () {
        var T = {
            cellpadding: "cellPadding",
            cellspacing: "cellSpacing",
            colspan: "colSpan",
            rowspan: "rowSpan",
            valign: "vAlign",
            usemap: "useMap",
            frameborder: "frameBorder"
        };
        if (a1.browser.ie < 8) {
            T["for"] = "htmlFor";
            T["class"] = "className"
        } else {
            T.htmlFor = "for";
            T.className = "class"
        }
        return T
    })();
    a1.dom.setAttr = function (cC, T, cD) {
        cC = a1.dom.g(cC);
        if ("style" == T) {
            cC.style.cssText = cD
        } else {
            T = a1.dom._NAME_ATTRS[T] || T;
            cC.setAttribute(T, cD)
        }
        return cC
    };
    a1.setAttr = a1.dom.setAttr;
    a1.dom.setAttrs = function (cD, T) {
        cD = a1.dom.g(cD);
        for (var cC in T) {
            a1.dom.setAttr(cD, cC, T[cC])
        }
        return cD
    };
    a1.setAttrs = a1.dom.setAttrs;
    a1.string = a1.string || {}; (function () {
        var T = new RegExp("(^[\\s\\t\\xa0\\u3000]+)|([\\u3000\\xa0\\s\\t]+\x24)", "g");
        a1.string.trim = function (cC) {
            return String(cC).replace(T, "")
        }
    })();
    a1.trim = a1.string.trim;
    a1.string.format = function (cD, T) {
        cD = String(cD);
        var cC = Array.prototype.slice.call(arguments, 1),
        cE = Object.prototype.toString;
        if (cC.length) {
            cC = cC.length == 1 ? (T !== null && (/\[object Array\]|\[object Object\]/.test(cE.call(T))) ? T : cC) : cC;
            return cD.replace(/#\{(.+?)\}/g,
            function (cF, cH) {
                var cG = cC[cH];
                if ("[object Function]" == cE.call(cG)) {
                    cG = cG(cH)
                }
                return ("undefined" == typeof cG ? "" : cG)
            })
        }
        return cD
    };
    a1.format = a1.string.format;
    a1.dom.removeClass = function (cG, cH) {
        cG = a1.dom.g(cG);
        var cE = cG.className.split(/\s+/),
        cI = cH.split(/\s+/),
        cC,
        T = cI.length,
        cD,
        cF = 0;
        for (; cF < T; ++cF) {
            for (cD = 0, cC = cE.length; cD < cC; ++cD) {
                if (cE[cD] == cI[cF]) {
                    cE.splice(cD, 1);
                    break
                }
            }
        }
        cG.className = cE.join(" ");
        return cG
    };
    a1.removeClass = a1.dom.removeClass;
    a1.dom.insertHTML = function (cE, T, cD) {
        cE = a1.dom.g(cE);
        var cC, cF;
        if (cE.insertAdjacentHTML) {
            cE.insertAdjacentHTML(T, cD)
        } else {
            cC = cE.ownerDocument.createRange();
            T = T.toUpperCase();
            if (T == "AFTERBEGIN" || T == "BEFOREEND") {
                cC.selectNodeContents(cE);
                cC.collapse(T == "AFTERBEGIN")
            } else {
                cF = T == "BEFOREBEGIN";
                cC[cF ? "setStartBefore" : "setEndAfter"](cE);
                cC.collapse(cF)
            }
            cC.insertNode(cC.createContextualFragment(cD))
        }
        return cE
    };
    a1.insertHTML = a1.dom.insertHTML;
    a1.dom.show = function (T) {
        T = a1.dom.g(T);
        T.style.display = "";
        return T
    };
    a1.show = a1.dom.show;
    a1.dom.getDocument = function (T) {
        T = a1.dom.g(T);
        return T.nodeType == 9 ? T : T.ownerDocument || T.document
    };
    a1.dom.addClass = function (cG, cH) {
        cG = a1.dom.g(cG);
        var cC = cH.split(/\s+/),
        T = cG.className,
        cF = " " + T + " ",
        cE = 0,
        cD = cC.length;
        for (; cE < cD; cE++) {
            if (cF.indexOf(" " + cC[cE] + " ") < 0) {
                T += " " + cC[cE]
            }
        }
        cG.className = T;
        return cG
    };
    a1.addClass = a1.dom.addClass;
    a1.dom._styleFixer = a1.dom._styleFixer || {};
    a1.dom._styleFilter = a1.dom._styleFilter || [];
    a1.dom._styleFilter.filter = function (cC, cF, cG) {
        for (var T = 0,
        cE = a1.dom._styleFilter,
        cD; cD = cE[T]; T++) {
            if (cD = cD[cG]) {
                cF = cD(cC, cF)
            }
        }
        return cF
    };
    a1.string.toCamelCase = function (T) {
        if (T.indexOf("-") < 0 && T.indexOf("_") < 0) {
            return T
        }
        return T.replace(/[-_][^-_]/g,
        function (cC) {
            return cC.charAt(1).toUpperCase()
        })
    };
    a1.dom.getStyle = function (cD, cC) {
        var cG = a1.dom;
        cD = cG.g(cD);
        cC = a1.string.toCamelCase(cC);
        var cF = cD.style[cC];
        if (!cF) {
            var T = cG._styleFixer[cC],
            cE = cD.currentStyle || (a1.browser.ie ? cD.style : getComputedStyle(cD, null));
            cF = T && T.get ? T.get(cD, cE) : cE[T || cC]
        }
        if (T = cG._styleFilter) {
            cF = T.filter(cC, cF, "get")
        }
        return cF
    };
    a1.getStyle = a1.dom.getStyle;
    if (/opera\/(\d+\.\d)/i.test(navigator.userAgent)) {
        a1.browser.opera = +RegExp["\x241"]
    }
    a1.browser.isWebkit = /webkit/i.test(navigator.userAgent);
    a1.browser.isGecko = /gecko/i.test(navigator.userAgent) && !/like gecko/i.test(navigator.userAgent);
    a1.browser.isStrict = document.compatMode == "CSS1Compat";
    a1.dom.getPosition = function (T) {
        T = a1.dom.g(T);
        var cK = a1.dom.getDocument(T),
        cE = a1.browser,
        cH = a1.dom.getStyle,
        cD = cE.isGecko > 0 && cK.getBoxObjectFor && cH(T, "position") == "absolute" && (T.style.top === "" || T.style.left === ""),
        cI = {
            left: 0,
            top: 0
        },
        cG = (cE.ie && !cE.isStrict) ? cK.body : cK.documentElement,
        cL,
        cC;
        if (T == cG) {
            return cI
        }
        if (T.getBoundingClientRect) {
            cC = T.getBoundingClientRect();
            cI.left = Math.floor(cC.left) + Math.max(cK.documentElement.scrollLeft, cK.body.scrollLeft);
            cI.top = Math.floor(cC.top) + Math.max(cK.documentElement.scrollTop, cK.body.scrollTop);
            cI.left -= cK.documentElement.clientLeft;
            cI.top -= cK.documentElement.clientTop;
            var cJ = cK.body,
            cM = parseInt(cH(cJ, "borderLeftWidth")),
            cF = parseInt(cH(cJ, "borderTopWidth"));
            if (cE.ie && !cE.isStrict) {
                cI.left -= isNaN(cM) ? 2 : cM;
                cI.top -= isNaN(cF) ? 2 : cF
            }
        } else {
            cL = T;
            do {
                cI.left += cL.offsetLeft;
                cI.top += cL.offsetTop;
                if (cE.isWebkit > 0 && cH(cL, "position") == "fixed") {
                    cI.left += cK.body.scrollLeft;
                    cI.top += cK.body.scrollTop;
                    break
                }
                cL = cL.offsetParent
            } while (cL && cL != T);
            if (cE.opera > 0 || (cE.isWebkit > 0 && cH(T, "position") == "absolute")) {
                cI.top -= cK.body.offsetTop
            }
            cL = T.offsetParent;
            while (cL && cL != cK.body) {
                cI.left -= cL.scrollLeft;
                if (!cE.opera || cL.tagName != "TR") {
                    cI.top -= cL.scrollTop
                }
                cL = cL.offsetParent
            }
        }
        return cI
    };
    if (/firefox\/(\d+\.\d)/i.test(navigator.userAgent)) {
        a1.browser.firefox = +RegExp["\x241"]
    } (function () {
        var T = navigator.userAgent;
        if (/(\d+\.\d)?(?:\.\d)?\s+safari\/?(\d+\.\d+)?/i.test(T) && !/chrome/i.test(T)) {
            a1.browser.safari = +(RegExp["\x241"] || RegExp["\x242"])
        }
    })();
    if (/chrome\/(\d+\.\d)/i.test(navigator.userAgent)) {
        a1.browser.chrome = +RegExp["\x241"]
    }
    a1.array = a1.array || {};
    a1.array.each = function (cG, cE) {
        var cD, cF, cC, T = cG.length;
        if ("function" == typeof cE) {
            for (cC = 0; cC < T; cC++) {
                cF = cG[cC];
                cD = cE.call(cG, cF, cC);
                if (cD === false) {
                    break
                }
            }
        }
        return cG
    };
    a1.each = a1.array.each;
    a1.lang.guid = function () {
        return "TANGRAM__" + (window[a1.guid]._counter++).toString(36)
    };
    window[a1.guid]._counter = window[a1.guid]._counter || 1;
    window[a1.guid]._instances = window[a1.guid]._instances || {};
    a1.lang.isFunction = function (T) {
        return "[object Function]" == Object.prototype.toString.call(T)
    };
    a1.lang.Class = function (T) {
        this.guid = T || a1.lang.guid();
        window[a1.guid]._instances[this.guid] = this
    };
    window[a1.guid]._instances = window[a1.guid]._instances || {};
    a1.lang.Class.prototype.dispose = function () {
        delete window[a1.guid]._instances[this.guid];
        for (var T in this) {
            if (!a1.lang.isFunction(this[T])) {
                delete this[T]
            }
        }
        this.disposed = true
    };
    a1.lang.Class.prototype.toString = function () {
        return "[object " + (this._className || "Object") + "]"
    };
    a1.lang.Event = function (T, cC) {
        this.type = T;
        this.returnValue = true;
        this.target = cC || null;
        this.currentTarget = null
    };
    a1.lang.Class.prototype.addEventListener = function (cE, cD, cC) {
        if (!a1.lang.isFunction(cD)) {
            return
        } !this.__listeners && (this.__listeners = {});
        var T = this.__listeners,
        cF;
        if (typeof cC == "string" && cC) {
            if (/[^\w\-]/.test(cC)) {
                throw ("nonstandard key:" + cC)
            } else {
                cD.hashCode = cC;
                cF = cC
            }
        }
        cE.indexOf("on") != 0 && (cE = "on" + cE);
        typeof T[cE] != "object" && (T[cE] = {});
        cF = cF || a1.lang.guid();
        cD.hashCode = cF;
        T[cE][cF] = cD
    };
    a1.lang.Class.prototype.removeEventListener = function (cD, cC) {
        if (a1.lang.isFunction(cC)) {
            cC = cC.hashCode
        } else {
            if (!a1.lang.isString(cC)) {
                return
            }
        } !this.__listeners && (this.__listeners = {});
        cD.indexOf("on") != 0 && (cD = "on" + cD);
        var T = this.__listeners;
        if (!T[cD]) {
            return
        }
        T[cD][cC] && delete T[cD][cC]
    };
    a1.lang.Class.prototype.dispatchEvent = function (cE, T) {
        if (a1.lang.isString(cE)) {
            cE = new a1.lang.Event(cE)
        } !this.__listeners && (this.__listeners = {});
        T = T || {};
        for (var cD in T) {
            cE[cD] = T[cD]
        }
        var cD, cC = this.__listeners,
        cF = cE.type;
        cE.target = cE.target || this;
        cE.currentTarget = this;
        cF.indexOf("on") != 0 && (cF = "on" + cF);
        a1.lang.isFunction(this[cF]) && this[cF].apply(this, arguments);
        if (typeof cC[cF] == "object") {
            for (cD in cC[cF]) {
                cC[cF][cD].apply(this, arguments)
            }
        }
        return cE.returnValue
    };
    a1.lang.inherits = function (cH, cF, cE) {
        var cD, cG, T = cH.prototype,
        cC = new Function();
        cC.prototype = cF.prototype;
        cG = cH.prototype = new cC();
        for (cD in T) {
            cG[cD] = T[cD]
        }
        cH.prototype.constructor = cH;
        cH.superClass = cF.prototype;
        if ("string" == typeof cE) {
            cG._className = cE
        }
    };
    a1.inherits = a1.lang.inherits;
    a1.lang.instance = function (T) {
        return window[a1.guid]._instances[T] || null
    };
    a1.platform = a1.platform || {};
    a1.platform.isMacintosh = /macintosh/i.test(navigator.userAgent);
    a1.platform.isWindows = /windows/i.test(navigator.userAgent);
    a1.platform.isX11 = /x11/i.test(navigator.userAgent);
    a1.platform.isAndroid = /android/i.test(navigator.userAgent);
    a1.platform.isIpad = /ipad/i.test(navigator.userAgent);
    a1.platform.isIphone = /iphone/i.test(navigator.userAgent);
    a1.lang.Event.prototype.inherit = function (cD) {
        var cC = this;
        this.domEvent = cD = window.event || cD;
        cC.clientX = cD.clientX || cD.pageX;
        cC.clientY = cD.clientY || cD.pageY;
        cC.offsetX = cD.offsetX || cD.layerX;
        cC.offsetY = cD.offsetY || cD.layerY;
        cC.screenX = cD.screenX;
        cC.screenY = cD.screenY;
        cC.ctrlKey = cD.ctrlKey || cD.metaKey;
        cC.shiftKey = cD.shiftKey;
        cC.altKey = cD.altKey;
        if (cD.touches) {
            cC.touches = [];
            for (var T = 0; T < cD.touches.length; T++) {
                cC.touches.push({
                    clientX: cD.touches[T].clientX,
                    clientY: cD.touches[T].clientY,
                    screenX: cD.touches[T].screenX,
                    screenY: cD.touches[T].screenY,
                    pageX: cD.touches[T].pageX,
                    pageY: cD.touches[T].pageY,
                    target: cD.touches[T].target,
                    identifier: cD.touches[T].identifier
                })
            }
        }
        if (cD.changedTouches) {
            cC.changedTouches = [];
            for (var T = 0; T < cD.changedTouches.length; T++) {
                cC.changedTouches.push({
                    clientX: cD.changedTouches[T].clientX,
                    clientY: cD.changedTouches[T].clientY,
                    screenX: cD.changedTouches[T].screenX,
                    screenY: cD.changedTouches[T].screenY,
                    pageX: cD.changedTouches[T].pageX,
                    pageY: cD.changedTouches[T].pageY,
                    target: cD.changedTouches[T].target,
                    identifier: cD.changedTouches[T].identifier
                })
            }
        }
        if (cD.targetTouches) {
            cC.targetTouches = [];
            for (var T = 0; T < cD.targetTouches.length; T++) {
                cC.targetTouches.push({
                    clientX: cD.targetTouches[T].clientX,
                    clientY: cD.targetTouches[T].clientY,
                    screenX: cD.targetTouches[T].screenX,
                    screenY: cD.targetTouches[T].screenY,
                    pageX: cD.targetTouches[T].pageX,
                    pageY: cD.targetTouches[T].pageY,
                    target: cD.targetTouches[T].target,
                    identifier: cD.targetTouches[T].identifier
                })
            }
        }
        cC.rotation = cD.rotation;
        cC.scale = cD.scale;
        return cC
    };
    a1.lang.decontrol = function (cC) {
        var T = window[a1.guid];
        T._instances && (delete T._instances[cC])
    };
    a1.event = {};
    a1.on = a1.event.on = function (cD, cC, T) {
        if (!(cD = a1.g(cD))) {
            return cD
        }
        cC = cC.replace(/^on/, "");
        if (cD.addEventListener) {
            cD.addEventListener(cC, T, false)
        } else {
            if (cD.attachEvent) {
                cD.attachEvent("on" + cC, T)
            }
        }
        return cD
    };
    a1.un = a1.event.un = function (cD, cC, T) {
        if (!(cD = a1.g(cD))) {
            return cD
        }
        cC = cC.replace(/^on/, "");
        if (cD.removeEventListener) {
            cD.removeEventListener(cC, T, false)
        } else {
            if (cD.detachEvent) {
                cD.detachEvent("on" + cC, T)
            }
        }
        return cD
    };
    a1.dom.hasClass = function (cD, cC) {
        if (!cD || !cD.className || typeof cD.className != "string") {
            return false
        }
        var T = -1;
        try {
            T = cD.className == cC || cD.className.search(new RegExp("(\\s|^)" + cC + "(\\s|$)"))
        } catch (cE) {
            return false
        }
        return T > -1
    };
    window.BMap = window.BMap || {};
    window.BMap.version = "1.2";
    window.BMap._register = [];
    window.BMap.register = function (T) {
        this._register.push(T)
    };
    window.BMap.apiLoad = window.BMap.apiLoad ||
    function () { };
    function bs(cE, cG) {
        cE = a1.g(cE);
        if (!cE) {
            return
        }
        var cF = this;
        a1.lang.Class.call(cF);
        cF.config = {
            clickInterval: 200,
            enableDragging: true,
            enableKeyboard: false,
            enableDblclickZoom: true,
            enableContinuousZoom: false,
            enableWheelZoom: false,
            enableMouseDown: true,
            enablePinchToZoom: true,
            enableAutoResize: true,
            fps: 25,
            zoomerDuration: 240,
            actionDuration: 450,
            defaultCursor: b3.defaultCursor,
            draggingCursor: b3.draggingCursor,
            isOverviewMap: false,
            minZoom: 1,
            maxZoom: 18,
            mapType: BMAP_NORMAL_MAP,
            restrictBounds: false,
            drawer: BMAP_SYS_DRAWER,
            enableInertialDragging: false,
            drawMargin: 500,
            enableHighResolution: false
        };
        a1.extend(cF.config, cG || {});
        if (cF.highResolutionEnabled()) {
            var cI = document.querySelector("meta[name=viewport]");
            cI.content = "initial-scale=0.5, minimum-scale=0.5, maximum-scale=0.5, user-scalable=no, target-densitydpi=high-dpi"
        }
        cF.container = cE;
        cF._setStyle(cE);
        cE.unselectable = "on";
        cE.innerHTML = "";
        cE.appendChild(cF.render());
        var cC = cF.getSize();
        cF.width = cC.width;
        cF.height = cC.height;
        cF.offsetX = 0;
        cF.offsetY = 0;
        cF.platform = cE.firstChild;
        cF.maskLayer = cF.platform.firstChild;
        cF.maskLayer.style.width = cF.width + "px";
        cF.maskLayer.style.height = cF.height + "px";
        cF._panes = {};
        cF.centerPoint = new b4(0, 0);
        cF.mercatorCenter = new b4(0, 0);
        cF.zoomLevel = 1;
        cF.lastLevel = 0;
        cF.defaultZoomLevel = null;
        cF.defaultCenter = null;
        cF.currentCity = "";
        cF.cityCode = "";
        cF._hotspots = {};
        cF.currentOperation = 0;
        cG = cG || {};
        var cH = cF.mapType = cF.config.mapType;
        cF.projection = cH.getProjection();
        if (cH === BMAP_PERSPECTIVE_MAP) {
            _addStat(5002)
        }
        if (cH === BMAP_SATELLITE_MAP || cH === BMAP_HYBRID_MAP) {
            _addStat(5003)
        }
        var T = cF.config;
        T.userMinZoom = cG.minZoom;
        T.userMaxZoom = cG.maxZoom;
        cF._checkZoom();
        cF.temp = {
            operating: false,
            arrow: 0,
            lastDomMoveTime: 0,
            lastLoadTileTime: 0,
            lastMovingTime: 0,
            canKeyboard: false,
            registerIndex: -1,
            curSpots: []
        };
        cF.platform.style.cursor = cF.config.defaultCursor;
        for (var cD = 0; cD < BMap._register.length; cD++) {
            BMap._register[cD](cF)
        }
        cF.temp.registerIndex = cD;
        cF._bind();
        cr.load("map",
        function () {
            cF._draw()
        });
        if (bG()) {
            cr.load("oppc",
            function () {
                cF._asyncRegister()
            })
        }
        if (av()) {
            cr.load("opmb",
            function () {
                cF._asyncRegister()
            })
        }
        cE = null
    }
    a1.lang.inherits(bs, a1.lang.Class, "Map");
    a1.extend(bs.prototype, {
        render: function () {
            var T = W("div");
            var cE = T.style;
            cE.overflow = "visible";
            cE.position = "absolute";
            cE.zIndex = "0";
            cE.top = cE.left = "0px";
            var cC = W("div", {
                "class": "BMap_mask"
            });
            var cD = cC.style;
            cD.position = "absolute";
            cD.top = cD.left = "0px";
            cD.zIndex = "9";
            cD.overflow = "hidden";
            cD.WebkitUserSelect = "none";
            T.appendChild(cC);
            return T
        },
        _setStyle: function (cC) {
            var T = cC.style;
            T.overflow = "hidden";
            if (aD(cC).position != "absolute") {
                T.position = "relative";
                T.zIndex = 0
            }
            T.backgroundColor = "#F3F1EC";
            T.color = "#000";
            T.textAlign = "left"
        },
        _bind: function () {
            var T = this;
            T._watchSize = function () {
                var cC = T.getSize();
                if (T.width != cC.width || T.height != cC.height) {
                    var cE = new aB(T.width, T.height);
                    var cF = new a9("onbeforeresize");
                    cF.size = cE;
                    T.dispatchEvent(cF);
                    T._updateCenterPoint((cC.width - T.width) / 2, (cC.height - T.height) / 2);
                    T.maskLayer.style.width = (T.width = cC.width) + "px";
                    T.maskLayer.style.height = (T.height = cC.height) + "px";
                    var cD = new a9("onresize");
                    cD.size = cC;
                    T.dispatchEvent(cD)
                }
            };
            if (T.config.enableAutoResize) {
                T.temp.autoResizeTimer = setInterval(T._watchSize, 80)
            }
        },
        _updateCenterPoint: function (cE, cC, cI, cH) {
            var cF = this.getMapType().getZoomUnits(this.getZoom());
            var cJ = this.projection;
            var cG = true;
            if (cI && b4.isInRange(cI)) {
                this.centerPoint = new b4(cI.lng, cI.lat);
                cG = false
            }
            var cD = (cI && cH) ? cJ.lngLatToMercator(cI, this.currentCity) : this.mercatorCenter;
            if (cD) {
                this.mercatorCenter = new b4(cD.lng + cE * cF, cD.lat - cC * cF);
                var T = cJ.mercatorToLngLat(this.mercatorCenter, this.currentCity);
                if (T && cG) {
                    this.centerPoint = T
                }
            }
        },
        zoomTo: function (cE, cC) {
            if (!aE(cE)) {
                return
            }
            cE = this._getProperZoom(cE).zoom;
            if (cE == this.zoomLevel) {
                return
            }
            this.lastLevel = this.zoomLevel;
            this.zoomLevel = cE;
            var cD;
            if (cC) {
                cD = cC
            } else {
                if (this.getInfoWindow()) {
                    cD = this.getInfoWindow().getPosition()
                }
            }
            if (cD) {
                var T = this.pointToPixel(cD, this.lastLevel);
                this._updateCenterPoint(this.width / 2 - T.x, this.height / 2 - T.y, this.pixelToPoint(T, this.lastLevel), true)
            }
            this.dispatchEvent(new a9("onzoomstart"));
            this.dispatchEvent(new a9("onzoomstartcode"))
        },
        setZoom: function (T) {
            this.zoomTo(T)
        },
        zoomIn: function (T) {
            this.zoomTo(this.zoomLevel + 1, T)
        },
        zoomOut: function (T) {
            this.zoomTo(this.zoomLevel - 1, T)
        },
        panTo: function (T, cC) {
            if (!(T instanceof b4)) {
                return
            }
            this.mercatorCenter = this.projection.lngLatToMercator(T, this.currentCity);
            if (b4.isInRange(T)) {
                this.centerPoint = new b4(T.lng, T.lat)
            } else {
                this.centerPoint = this.projection.mercatorToLngLat(this.mercatorCenter, this.currentCity)
            }
        },
        panBy: function (cC, T) {
            cC = Math.round(cC) || 0;
            T = Math.round(T) || 0;
            this._updateCenterPoint(-cC, -T)
        },
        addControl: function (T) {
            if (T && G(T._i)) {
                T._i(this);
                this.dispatchEvent(new a9("onaddcontrol", T))
            }
        },
        removeControl: function (T) {
            if (T && G(T.remove)) {
                T.remove();
                this.dispatchEvent(new a9("onremovecontrol", T))
            }
        },
        addContextMenu: function (T) {
            if (T && G(T.initialize)) {
                T.initialize(this);
                this.dispatchEvent(new a9("onaddcontextmenu", T))
            }
        },
        removeContextMenu: function (T) {
            if (T && G(T.remove)) {
                this.dispatchEvent(new a9("onremovecontextmenu", T));
                T.remove()
            }
        },
        addOverlay: function (T) {
            if (T && G(T._i)) {
                T._i(this);
                this.dispatchEvent(new a9("onaddoverlay", T))
            }
        },
        removeOverlay: function (T) {
            if (T && G(T.remove)) {
                T.remove();
                this.dispatchEvent(new a9("onremoveoverlay", T))
            }
        },
        clearOverlays: function () {
            this.dispatchEvent(new a9("onclearoverlays"))
        },
        addTileLayer: function (T) {
            if (T) {
                this.dispatchEvent(new a9("onaddtilelayer", T))
            }
        },
        removeTileLayer: function (T) {
            if (T) {
                this.dispatchEvent(new a9("onremovetilelayer", T))
            }
        },
        setMapType: function (cC) {
            if (this.mapType === cC) {
                return
            }
            var cD = new a9("onsetmaptype");
            var T = this.mapType;
            cD.preMapType = T;
            this.mapType = this.config.mapType = cC;
            this.projection = this.mapType.getProjection();
            this._updateCenterPoint(0, 0, this.getCenter(), true);
            this._checkZoom();
            var cE = this._getProperZoom(this.getZoom()).zoom;
            this.zoomTo(cE);
            this.dispatchEvent(cD);
            var cD = new a9("onmaptypechange");
            cD.zoomLevel = cE;
            cD.mapType = cC;
            this.dispatchEvent(cD);
            if (cC === BMAP_SATELLITE_MAP || cC === BMAP_HYBRID_MAP) {
                _addStat(5003)
            }
        },
        setCenter: function (T) {
            var cD = this;
            if (T instanceof b4) {
                cD.panTo(T, {
                    noAnimation: true
                })
            } else {
                if (bV(T)) {
                    var cC = this._getLocal();
                    cC.setSearchCompleteCallback(function (cE) {
                        if (cC.getStatus() == 0 && cC._json.result.type == 2) {
                            cD.setCenter(cE.getPoi(0).point);
                            if (BMAP_PERSPECTIVE_MAP.getCityName(T)) {
                                cD.setCurrentCity(T)
                            }
                        }
                    });
                    cC.search(T)
                }
            }
        },
        centerAndZoom: function (T, cD) {
            var cC = this;
            if (bV(T)) {
                var cG = cC._getLocal();
                cG.setSearchCompleteCallback(function (cH) {
                    if (cG.getStatus() == 0 && cG._json.result.type == 2) {
                        var cJ = cH.getPoi(0).point;
                        var cI = cD || P.getBestLevel(cG._json.content.level, cC);
                        cC.centerAndZoom(cJ, cI);
                        if (BMAP_PERSPECTIVE_MAP.getCityName(T)) {
                            cC.setCurrentCity(T)
                        }
                    }
                });
                cG.search(T);
                return
            }
            if (!(T instanceof b4) || !cD) {
                return
            }
            cD = cC._getProperZoom(cD).zoom;
            cC.lastLevel = cC.zoomLevel || cD;
            cC.zoomLevel = cD;
            cC.centerPoint = new b4(T.lng, T.lat);
            cC.mercatorCenter = cC.projection.lngLatToMercator(cC.centerPoint, cC.currentCity);
            cC.defaultZoomLevel = cC.defaultZoomLevel || cC.zoomLevel;
            cC.defaultCenter = cC.defaultCenter || cC.centerPoint;
            var cF = new a9("onload");
            var cE = new a9("onloadcode");
            cF.point = new b4(T.lng, T.lat);
            cF.pixel = cC.pointToPixel(cC.centerPoint, cC.zoomLevel);
            cF.zoom = cD;
            if (!cC.loaded) {
                cC.loaded = true;
                cC.dispatchEvent(cF)
            }
            cC.dispatchEvent(cE);
            cC.dispatchEvent(new a9("onmoveend"));
            if (cC.lastLevel != cC.zoomLevel) {
                cC.dispatchEvent(new a9("onzoomend"))
            }
        },
        _getLocal: function () {
            if (!this.temp.local) {
                this.temp.local = new aX(1)
            }
            return this.temp.local
        },
        reset: function () {
            this.centerAndZoom(this.defaultCenter, this.defaultZoomLevel, true)
        },
        enableDragging: function () {
            this.config.enableDragging = true
        },
        disableDragging: function () {
            this.config.enableDragging = false
        },
        enableInertialDragging: function () {
            this.config.enableInertialDragging = true
        },
        disableInertialDragging: function () {
            this.config.enableInertialDragging = false
        },
        enableScrollWheelZoom: function () {
            this.config.enableWheelZoom = true
        },
        disableScrollWheelZoom: function () {
            this.config.enableWheelZoom = false
        },
        enableContinuousZoom: function () {
            this.config.enableContinuousZoom = true
        },
        disableContinuousZoom: function () {
            this.config.enableContinuousZoom = false
        },
        enableDoubleClickZoom: function () {
            this.config.enableDblclickZoom = true
        },
        disableDoubleClickZoom: function () {
            this.config.enableDblclickZoom = false
        },
        enableKeyboard: function () {
            this.config.enableKeyboard = true
        },
        disableKeyboard: function () {
            this.config.enableKeyboard = false
        },
        enablePinchToZoom: function () {
            this.config.enablePinchToZoom = true
        },
        disablePinchToZoom: function () {
            this.config.enablePinchToZoom = false
        },
        enableAutoResize: function () {
            this.config.enableAutoResize = true;
            this._watchSize();
            if (!this.temp.autoResizeTimer) {
                this.temp.autoResizeTimer = setInterval(this._watchSize, 80)
            }
        },
        disableAutoResize: function () {
            this.config.enableAutoResize = false;
            if (this.temp.autoResizeTimer) {
                clearInterval(this.temp.autoResizeTimer);
                this.temp.autoResizeTimer = null
            }
        },
        getSize: function () {
            return new aB(this.container.clientWidth, this.container.clientHeight)
        },
        getCenter: function () {
            return this.centerPoint
        },
        getZoom: function () {
            return this.zoomLevel
        },
        checkResize: function () {
            this._watchSize()
        },
        _getProperZoom: function (cD) {
            var cC = this.config.minZoom,
            T = this.config.maxZoom,
            cE = false;
            if (cD < cC) {
                cE = true;
                cD = cC
            }
            if (cD > T) {
                cE = true;
                cD = T
            }
            return {
                zoom: cD,
                exceeded: cE
            }
        },
        getContainer: function () {
            return this.container
        },
        pointToPixel: function (T, cC) {
            cC = cC || this.getZoom();
            return this.projection.pointToPixel(T, cC, this.mercatorCenter, this.getSize(), this.currentCity)
        },
        pixelToPoint: function (T, cC) {
            cC = cC || this.getZoom();
            return this.projection.pixelToPoint(T, cC, this.mercatorCenter, this.getSize(), this.currentCity)
        },
        pointToOverlayPixel: function (T, cD) {
            if (!T) {
                return
            }
            var cE = new b4(T.lng, T.lat);
            var cC = this.pointToPixel(cE, cD);
            cC.x -= this.offsetX;
            cC.y -= this.offsetY;
            return cC
        },
        overlayPixelToPoint: function (T, cD) {
            if (!T) {
                return
            }
            var cC = new bn(T.x, T.y);
            cC.x += this.offsetX;
            cC.y += this.offsetY;
            return this.pixelToPoint(cC, cD)
        },
        getBounds: function () {
            if (!this.isLoaded()) {
                return new bF()
            }
            var cC = arguments[0] || {},
            cE = cC.margins || [0, 0, 0, 0],
            T = cC.zoom || null,
            cF = this.pixelToPoint({
                x: cE[3],
                y: this.height - cE[2]
            },
            T),
            cD = this.pixelToPoint({
                x: this.width - cE[1],
                y: cE[0]
            },
            T);
            return new bF(cF, cD)
        },
        isLoaded: function () {
            return !!this.loaded
        },
        _getBestLevel: function (cC, cD) {
            var cG = this.getMapType();
            var cI = cD.margins || [10, 10, 10, 10],
            cF = cD.zoomFactor || 0,
            cJ = cI[1] + cI[3],
            cH = cI[0] + cI[2],
            T = cG.getMinZoom(),
            cL = cG.getMaxZoom();
            for (var cE = cL; cE >= T; cE--) {
                var cK = this.getMapType().getZoomUnits(cE);
                if (cC.toSpan().lng / cK < this.width - cJ && cC.toSpan().lat / cK < this.height - cH) {
                    break
                }
            }
            cE += cF;
            if (cE < T) {
                cE = T
            }
            if (cE > cL) {
                cE = cL
            }
            return cE
        },
        getViewport: function (cK, cC) {
            var cO = {
                center: this.getCenter(),
                zoom: this.getZoom()
            };
            if (!cK || !cK instanceof bF && cK.length == 0 || cK instanceof bF && cK.isEmpty()) {
                return cO
            }
            var cM = [];
            if (cK instanceof bF) {
                cM.push(cK.getNorthEast());
                cM.push(cK.getSouthWest())
            } else {
                cM = cK.slice(0)
            }
            cC = cC || {};
            var cG = [];
            for (var cH = 0,
            cF = cM.length; cH < cF; cH++) {
                cG.push(this.projection.lngLatToMercator(cM[cH], this.currentCity))
            }
            var cD = new bF();
            for (var cH = cG.length - 1; cH >= 0; cH--) {
                cD.extend(cG[cH])
            }
            if (cD.isEmpty()) {
                return cO
            }
            var T = cD.getCenter();
            var cN = this._getBestLevel(cD, cC);
            if (cC.margins) {
                var cJ = cC.margins,
                cI = (cJ[1] - cJ[3]) / 2,
                cL = (cJ[0] - cJ[2]) / 2,
                cE = this.getMapType().getZoomUnits(cN);
                T.lng = T.lng + cE * cI;
                T.lat = T.lat + cE * cL
            }
            T = this.projection.mercatorToLngLat(T, this.currentCity);
            return {
                center: T,
                zoom: cN
            }
        },
        setViewport: function (cC, cF) {
            var T;
            if (cC && cC.center) {
                T = cC
            } else {
                T = this.getViewport(cC, cF)
            }
            cF = cF || {};
            var cD = cF.delay || 200;
            if (T.zoom == this.zoomLevel && cF.enableAnimation != false) {
                var cE = this;
                setTimeout(function () {
                    cE.panTo(T.center, {
                        duration: 210
                    })
                },
                cD)
            } else {
                this.centerAndZoom(T.center, T.zoom)
            }
        },
        getPanes: function () {
            return this._panes
        },
        getInfoWindow: function () {
            if (this.temp.infoWin && this.temp.infoWin.isOpen()) {
                return this.temp.infoWin
            }
            return null
        },
        getDistance: function (cD, T) {
            if (!cD || !T) {
                return
            }
            var cC = 0;
            cC = a3.getDistanceByLL(cD, T);
            return cC
        },
        getOverlays: function () {
            var cE = [],
            cF = this._overlays,
            cD = this._customOverlays;
            if (cF) {
                for (var cC in cF) {
                    if (cF[cC] instanceof U) {
                        cE.push(cF[cC])
                    }
                }
            }
            if (cD) {
                for (var cC = 0,
                T = cD.length; cC < T; cC++) {
                    cE.push(cD[cC])
                }
            }
            return cE
        },
        getMapType: function () {
            return this.mapType
        },
        _asyncRegister: function () {
            for (var T = this.temp.registerIndex; T < BMap._register.length; T++) {
                BMap._register[T](this)
            }
            this.temp.registerIndex = T
        },
        setCurrentCity: function (T) {
            this.currentCity = BMAP_PERSPECTIVE_MAP.getCityName(T);
            this.cityCode = BMAP_PERSPECTIVE_MAP.getCityCode(this.currentCity)
        },
        setDefaultCursor: function (T) {
            this.config.defaultCursor = T;
            if (this.platform) {
                this.platform.style.cursor = this.config.defaultCursor
            }
        },
        getDefaultCursor: function () {
            return this.config.defaultCursor
        },
        setDraggingCursor: function (T) {
            this.config.draggingCursor = T
        },
        getDraggingCursor: function () {
            return this.config.draggingCursor
        },
        highResolutionEnabled: function () {
            return this.config.enableHighResolution && window.devicePixelRatio > 1
        },
        addHotspot: function (cC) {
            if (cC instanceof cd) {
                this._hotspots[cC.guid] = cC;
                cC.initialize(this)
            }
            var T = this;
            cr.load("hotspot",
            function () {
                T._asyncRegister()
            })
        },
        removeHotspot: function (T) {
            if (this._hotspots[T.guid]) {
                delete this._hotspots[T.guid]
            }
        },
        clearHotspots: function () {
            this._hotspots = {}
        },
        _checkZoom: function () {
            var cC = this.mapType.getMinZoom();
            var cD = this.mapType.getMaxZoom();
            var T = this.config;
            T.minZoom = T.userMinZoom || cC;
            T.maxZoom = T.userMaxZoom || cD;
            if (T.minZoom < cC) {
                T.minZoom = cC
            }
            if (T.maxZoom > cD) {
                T.maxZoom = cD
            }
        },
        setMinZoom: function (T) {
            if (T > this.config.maxZoom) {
                T = this.config.maxZoom
            }
            this.config.userMinZoom = T;
            this._updateZoom()
        },
        setMaxZoom: function (T) {
            if (T < this.config.minZoom) {
                T = this.config.minZoom
            }
            this.config.userMaxZoom = T;
            this._updateZoom()
        },
        _updateZoom: function () {
            this._checkZoom();
            var T = this.config;
            if (this.zoomLevel < T.minZoom) {
                this.setZoom(T.minZoom)
            } else {
                if (this.zoomLevel > T.maxZoom) {
                    this.setZoom(T.maxZoom)
                }
            }
            var cC = new a9("onzoomspanchange");
            cC.minZoom = T.minZoom;
            cC.maxZoom = T.maxZoom;
            this.dispatchEvent(cC)
        }
    });
    window.BMAP_API_VERSION = "1.2";
    window.BMAP_COORD_LNGLAT = 0;
    window.BMAP_COORD_MERCATOR = 1;
    window.BMAP_SYS_DRAWER = 0;
    window.BMAP_SVG_DRAWER = 1;
    window.BMAP_VML_DRAWER = 2;
    window.BMAP_CANVAS_DRAWER = 3;
    window._addStat = function (cG, cF) {
        if (!cG) {
            return
        }
        cF = cF || {};
        var cE = "";
        for (var cC in cF) {
            cE = cE + "&" + cC + "=" + encodeURIComponent(cF[cC])
        }
        var cH = function (cI) {
            if (!cI) {
                return
            }
            _addStat._sending = true;
            setTimeout(function () {
                _addStat._img.src = b3.imgPath + "blank.gif?" + cI.src
            },
            50)
        };
        var T = function () {
            var cI = _addStat._reqQueue.shift();
            if (cI) {
                cH(cI)
            }
        };
        var cD = (Math.random() * 100000000).toFixed(0);
        if (_addStat._sending) {
            _addStat._reqQueue.push({
                src: "t=" + cD + "&code=" + cG + cE
            })
        } else {
            cH({
                src: "t=" + cD + "&code=" + cG + cE
            })
        }
        if (!_addStat._binded) {
            a1.on(_addStat._img, "load",
            function () {
                _addStat._sending = false;
                T()
            });
            a1.on(_addStat._img, "error",
            function () {
                _addStat._sending = false;
                T()
            });
            _addStat._binded = true
        }
    };
    window._addStat._reqQueue = [];
    window._addStat._img = new Image();
    _addStat(5000, {
        v: BMap.version
    });
    function g(cE) {
        var T = {
            duration: 1000,
            fps: 30,
            delay: 0,
            transition: aq.linear,
            onStop: function () { }
        };
        this._anis = [];
        if (cE) {
            for (var cC in cE) {
                T[cC] = cE[cC]
            }
        }
        this._opts = T;
        if (aE(T.delay)) {
            var cD = this;
            setTimeout(function () {
                cD.start()
            },
            T.delay)
        } else {
            if (T.delay != g.INFINITE) {
                this.start()
            }
        }
    }
    g.INFINITE = "INFINITE";
    g.prototype.start = function () {
        this._beginTime = az();
        this._endTime = this._beginTime + this._opts.duration;
        this._launch()
    };
    g.prototype.add = function (T) {
        this._anis.push(T)
    };
    g.prototype._launch = function () {
        var cD = this;
        var T = az();
        if (T >= cD._endTime) {
            if (G(cD._opts.render)) {
                cD._opts.render(cD._opts.transition(1))
            }
            if (G(cD._opts.finish)) {
                cD._opts.finish()
            }
            if (cD._anis.length > 0) {
                var cC = cD._anis[0];
                cC._anis = [].concat(cD._anis.slice(1));
                cC.start()
            }
            return
        }
        cD.schedule = cD._opts.transition((T - cD._beginTime) / cD._opts.duration);
        if (G(cD._opts.render)) {
            cD._opts.render(cD.schedule)
        }
        if (!cD.terminative) {
            cD._timer = setTimeout(function () {
                cD._launch()
            },
            1000 / cD._opts.fps)
        }
    };
    g.prototype.stop = function (cC) {
        this.terminative = true;
        for (var T = 0; T < this._anis.length; T++) {
            this._anis[T].stop();
            this._anis[T] = null
        }
        this._anis.length = 0;
        if (this._timer) {
            clearTimeout(this._timer);
            this._timer = null
        }
        this._opts.onStop(this.schedule);
        if (cC) {
            this._endTime = this._beginTime;
            this._launch()
        }
    };
    g.prototype.cancel = function () {
        if (this._timer) {
            clearTimeout(this._timer)
        }
        this._endTime = this._beginTime;
        this.schedule = 0
    };
    g.prototype.setFinishCallback = function (T) {
        if (this._anis.length > 0) {
            this._anis[this._anis.length - 1]._opts.finish = T
        } else {
            this._opts.finish = T
        }
    };
    var aq = {
        linear: function (T) {
            return T
        },
        reverse: function (T) {
            return 1 - T
        },
        easeInQuad: function (T) {
            return T * T
        },
        easeInCubic: function (T) {
            return Math.pow(T, 3)
        },
        easeOutQuad: function (T) {
            return -(T * (T - 2))
        },
        easeOutCubic: function (T) {
            return Math.pow((T - 1), 3) + 1
        },
        easeInOutQuad: function (T) {
            if (T < 0.5) {
                return T * T * 2
            } else {
                return -2 * (T - 2) * T - 1
            }
            return
        },
        easeInOutCubic: function (T) {
            if (T < 0.5) {
                return Math.pow(T, 3) * 4
            } else {
                return Math.pow(T - 1, 3) * 4 + 1
            }
        },
        easeInOutSine: function (T) {
            return (1 - Math.cos(Math.PI * T)) / 2
        }
    };
    aq["ease-in"] = aq.easeInQuad;
    aq["ease-out"] = aq.easeOutQuad;
    var b3 = {
        imgPath: "http://api.map.baidu.com/images/",
        cityNames: {
            "\u5317\u4eac": "bj",
            "\u4e0a\u6d77": "sh",
            "\u6df1\u5733": "sz",
            "\u5e7f\u5dde": "gz"
        },
        fontFamily: "arial,sans-serif"
    };
    if (a1.browser.firefox) {
        a1.extend(b3, {
            distCursor: "url(" + b3.imgPath + "ruler.cur),crosshair",
            defaultCursor: "-moz-grab",
            draggingCursor: "-moz-grabbing"
        });
        if (a1.platform.isWindows) {
            b3.fontFamily = "arial,simsun,sans-serif"
        }
    } else {
        if (a1.browser.chrome || a1.browser.safari) {
            a1.extend(b3, {
                distCursor: "url(" + b3.imgPath + "ruler.cur) 2 6,crosshair",
                defaultCursor: "url(" + b3.imgPath + "openhand.cur) 8 8,default",
                draggingCursor: "url(" + b3.imgPath + "closedhand.cur) 8 8,move"
            })
        } else {
            a1.extend(b3, {
                distCursor: "url(" + b3.imgPath + "ruler.cur),crosshair",
                defaultCursor: "url(" + b3.imgPath + "openhand.cur),default",
                draggingCursor: "url(" + b3.imgPath + "closedhand.cur),move"
            })
        }
    }
    function ap(cD, cC, T) {
        this.id = cD;
        this.bounds = cC;
        this.content = T
    }
    var bg = {
        undo: 1,
        redo: 2,
        zoom: 4,
        drag: 8,
        move: 16,
        mousewheel: 32,
        toolbarOperation: 64,
        stdMapCtrlDrag: 128,
        dblclick: 256
    };
    function bB(cD, T) {
        var cC = cD.style;
        cC.left = T[0] + "px";
        cC.top = T[1] + "px"
    }
    function cn(T) {
        if (a1.browser.ie > 0) {
            T.unselectable = "on"
        } else {
            T.style.MozUserSelect = "none"
        }
    }
    function w(T) {
        return T && T.parentNode && T.parentNode.nodeType != 11
    }
    function an(cC, T) {
        a1.dom.insertHTML(cC, "beforeEnd", T);
        return cC.lastChild
    }
    function bQ(T) {
        var cC = {
            left: 0,
            top: 0
        };
        while (T && T.offsetParent) {
            cC.left += T.offsetLeft;
            cC.top += T.offsetTop;
            T = T.offsetParent
        }
        return cC
    }
    function aJ(T) {
        var T = window.event || T;
        T.stopPropagation ? T.stopPropagation() : T.cancelBubble = true
    }
    function ct(T) {
        var T = window.event || T;
        T.preventDefault ? T.preventDefault() : T.returnValue = false;
        return false
    }
    function cf(T) {
        aJ(T);
        return ct(T)
    }
    function cx() {
        var T = document.documentElement,
        cC = document.body;
        if (T && (T.scrollTop || T.scrollLeft)) {
            return [T.scrollTop, T.scrollLeft]
        } else {
            if (cC) {
                return [cC.scrollTop, cC.scrollLeft]
            } else {
                return [0, 0]
            }
        }
    }
    function ck(cC, T) {
        if (!cC || !T) {
            return
        }
        return Math.round(Math.sqrt(Math.pow(cC.x - T.x, 2) + Math.pow(cC.y - T.y, 2)))
    }
    function M(T, cD) {
        var cC = [];
        cD = cD ||
        function (cF) {
            return cF
        };
        for (var cE in T) {
            cC.push(cE + "=" + cD(T[cE]))
        }
        return cC.join("&")
    }
    function W(cC, T, cD) {
        var cE = document.createElement(cC);
        if (cD) {
            cE = document.createElementNS(cD, cC)
        }
        return a1.dom.setAttrs(cE, T || {})
    }
    function aD(T) {
        if (T.currentStyle) {
            return T.currentStyle
        } else {
            if (T.ownerDocument && T.ownerDocument.defaultView) {
                return T.ownerDocument.defaultView.getComputedStyle(T, null)
            }
        }
    }
    function G(T) {
        return typeof T == "function"
    }
    function aE(T) {
        return typeof T == "number"
    }
    function bV(T) {
        return typeof T == "string"
    }
    function b8(T) {
        return typeof T != "undefined"
    }
    function cA(T) {
        return typeof T == "object"
    }
    function aS(T) {
        return "[object Array]" == Object.prototype.toString.call(T)
    }
    var b6 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
    function bN(cE) {
        var cC = "";
        var cL, cJ, cH = "";
        var cK, cI, cG, cF = "";
        var cD = 0;
        var T = /[^A-Za-z0-9\+\/\=]/g;
        if (!cE || T.exec(cE)) {
            return cE
        }
        cE = cE.replace(/[^A-Za-z0-9\+\/\=]/g, "");
        do {
            cK = b6.indexOf(cE.charAt(cD++));
            cI = b6.indexOf(cE.charAt(cD++));
            cG = b6.indexOf(cE.charAt(cD++));
            cF = b6.indexOf(cE.charAt(cD++));
            cL = (cK << 2) | (cI >> 4);
            cJ = ((cI & 15) << 4) | (cG >> 2);
            cH = ((cG & 3) << 6) | cF;
            cC = cC + String.fromCharCode(cL);
            if (cG != 64) {
                cC = cC + String.fromCharCode(cJ)
            }
            if (cF != 64) {
                cC = cC + String.fromCharCode(cH)
            }
            cL = cJ = cH = "";
            cK = cI = cG = cF = ""
        } while (cD < cE.length);
        return cC
    }
    var a9 = a1.lang.Event;
    function av() {
        return !!(a1.platform.isIphone || a1.platform.isIpad || a1.platform.isAndroid)
    }
    function bG() {
        return !!(a1.platform.isWindows || a1.platform.isMacintosh || a1.platform.isX11)
    }
    function az() {
        return (new Date).getTime()
    }
    var co = {
        request: function (cC) {
            var T = W("script", {
                src: cC,
                type: "text/javascript",
                charset: "utf-8"
            });
            if (T.addEventListener) {
                T.addEventListener("load",
                function (cE) {
                    var cD = cE.target;
                    cD.parentNode.removeChild(cD)
                },
                false)
            } else {
                if (T.attachEvent) {
                    T.attachEvent("onreadystatechange",
                    function (cE) {
                        var cD = window.event.srcElement;
                        if (cD && (cD.readyState == "loaded" || cD.readyState == "complete")) {
                            cD.parentNode.removeChild(cD)
                        }
                    })
                }
            }
            setTimeout(function () {
                document.getElementsByTagName("head")[0].appendChild(T);
                T = null
            },
            1)
        }
    };
    function cr() { }
    a1.object.extend(cr, {
        Request: {
            INITIAL: -1,
            WAITING: 0,
            COMPLETED: 1
        },
        Dependency: {
            control: [],
            marker: [],
            poly: ["marker"],
            infowindow: ["marker"],
            menu: [],
            oppc: [],
            opmb: [],
            scommon: [],
            local: ["scommon"],
            route: ["scommon"],
            othersearch: ["scommon"],
            autocomplete: ["scommon"],
            buslinesearch: ["route"],
            hotspot: []
        },
        preLoaded: {},
        Config: {
            _baseUrl: "http://api.map.baidu.com/getmodules?v=1.2",
            _timeout: 5000
        },
        delayFlag: false,
        Module: {
            _modules: {},
            _arrMdls: []
        },
        load: function (cC, cE) {
            var T = this.current(cC);
            if (T._status == this.Request.COMPLETED) {
                return
            } else {
                if (T._status == this.Request.INITIAL) {
                    this.combine(cC);
                    this.pushUniqueMdl(cC);
                    var cD = this;
                    if (cD.delayFlag == false) {
                        cD.delayFlag = true;
                        window.setTimeout(function () {
                            var cF = cD.Config._baseUrl + "&mod=" + cD.Module._arrMdls.join(",");
                            co.request(cF);
                            cD.Module._arrMdls.length = 0;
                            cD.delayFlag = false
                        },
                        1)
                    }
                    T._status = this.Request.WAITING
                }
                T._callbacks.push(cE)
            }
        },
        combine: function (T) {
            if (T && this.Dependency[T]) {
                var cD = this.Dependency[T];
                for (var cC = 0; cC < cD.length; cC++) {
                    this.combine(cD[cC]);
                    if (!this.Module._modules[cD[cC]]) {
                        this.pushUniqueMdl(cD[cC])
                    }
                }
            }
        },
        pushUniqueMdl: function (cC) {
            for (var T = 0; T < this.Module._arrMdls.length; T++) {
                if (this.Module._arrMdls[T] == cC) {
                    return
                }
            }
            this.Module._arrMdls.push(cC)
        },
        run: function (cD, cF) {
            var cC = this.current(cD);
            try {
                eval(cF)
            } catch (cG) {
                return
            }
            cC._status = this.Request.COMPLETED;
            for (var cE = 0,
            T = cC._callbacks.length; cE < T; cE++) {
                cC._callbacks[cE]()
            }
            cC._callbacks.length = 0
        },
        check: function (cC, cD) {
            var T = this;
            T.timeout = setTimeout(function () {
                var cE = T.Module._modules[cC]._status;
                if (cE != T.Request.COMPLETED) {
                    T.remove(cC);
                    T.load(cC, cD)
                } else {
                    clearTimeout(T.timeout)
                }
            },
            T.Config._timeout)
        },
        current: function (cC) {
            var T;
            if (!this.Module._modules[cC]) {
                this.Module._modules[cC] = {};
                this.Module._modules[cC]._status = this.Request.INITIAL;
                this.Module._modules[cC]._callbacks = []
            }
            T = this.Module._modules[cC];
            return T
        },
        remove: function (cC) {
            var T = this.current(cC);
            delete T
        }
    });
    window._jsload = function (T, cC) {
        cr.run(T, cC)
    };
    function bn(T, cC) {
        this.x = T || 0;
        this.y = cC || 0
    }
    bn.prototype.equals = function (T) {
        return T && T.x == this.x && T.y == this.y
    };
    function aB(cC, T) {
        this.width = cC || 0;
        this.height = T || 0
    }
    aB.prototype.equals = function (T) {
        return T && this.width == T.width && this.height == T.height
    };
    function cd(T, cC) {
        if (!T) {
            return
        }
        this._position = T;
        this.guid = "spot" + (cd.guid++);
        cC = cC || {};
        this._text = cC.text || "";
        this._offsets = cC.offsets ? cC.offsets.slice(0) : [5, 5, 5, 5];
        this._userData = cC.userData || null;
        this._minZoom = cC.minZoom || null;
        this._maxZoom = cC.maxZoom || null
    }
    cd.guid = 0;
    a1.extend(cd.prototype, {
        initialize: function (T) {
            if (this._minZoom == null) {
                this._minZoom = T.config.minZoom
            }
            if (this._maxZoom == null) {
                this._maxZoom = T.config.maxZoom
            }
        },
        setPosition: function (T) {
            if (T instanceof b4) {
                this._position = T
            }
        },
        getPosition: function () {
            return this._position
        },
        setText: function (T) {
            this._text = T
        },
        getText: function () {
            return this._text
        },
        setUserData: function (T) {
            this._userData = T
        },
        getUserData: function () {
            return this._userData
        }
    });
    function cg() {
        this._map = null;
        this._container;
        this._type = "control";
        this.blockInfoWindow = true;
        this._visible = true
    }
    a1.lang.inherits(cg, a1.lang.Class, "Control");
    a1.extend(cg.prototype, {
        initialize: function (T) {
            this._map = T;
            if (this._container) {
                T.container.appendChild(this._container);
                return this._container
            }
            return
        },
        _i: function (T) {
            if (!this._container && this.initialize && G(this.initialize)) {
                this._container = this.initialize(T)
            }
            this._opts = this._opts || {
                printable: false
            };
            this._setStyle();
            this._setPosition();
            if (this._container) {
                this._container._jsobj = this
            }
        },
        _setStyle: function () {
            var cC = this._container;
            if (cC) {
                var T = cC.style;
                T.position = "absolute";
                T.zIndex = this._cZIndex || "10";
                T.MozUserSelect = "none";
                T.WebkitTextSizeAdjust = "none";
                if (!this._opts.printable) {
                    a1.dom.addClass(cC, "BMap_noprint")
                }
                a1.on(cC, "contextmenu", cf)
            }
        },
        remove: function () {
            this._map = null;
            if (!this._container) {
                return
            }
            this._container.parentNode && this._container.parentNode.removeChild(this._container);
            this._container._jsobj = null;
            this._container = null
        },
        _render: function () {
            this._container = an(this._map.container, "<div unselectable='on'></div>");
            if (this._visible == false) {
                a1.dom.hide(this._container)
            }
            return this._container
        },
        _setPosition: function () {
            this.setAnchor(this._opts.anchor)
        },
        setAnchor: function (cE) {
            if (this.anchorFixed || !aE(cE) || isNaN(cE) || cE < BMAP_ANCHOR_TOP_LEFT || cE > BMAP_ANCHOR_BOTTOM_RIGHT) {
                cE = this.defaultAnchor
            }
            this._opts = this._opts || {
                printable: false
            };
            this._opts.offset = this._opts.offset || this.defaultOffset;
            var cD = this._opts.anchor;
            this._opts.anchor = cE;
            if (!this._container) {
                return
            }
            var cG = this._container;
            var T = this._opts.offset.width;
            var cF = this._opts.offset.height;
            cG.style.left = cG.style.top = cG.style.right = cG.style.bottom = "auto";
            switch (cE) {
                case BMAP_ANCHOR_TOP_LEFT:
                    cG.style.top = cF + "px";
                    cG.style.left = T + "px";
                    break;
                case BMAP_ANCHOR_TOP_RIGHT:
                    cG.style.top = cF + "px";
                    cG.style.right = T + "px";
                    break;
                case BMAP_ANCHOR_BOTTOM_LEFT:
                    cG.style.bottom = cF + "px";
                    cG.style.left = T + "px";
                    break;
                case BMAP_ANCHOR_BOTTOM_RIGHT:
                    cG.style.bottom = cF + "px";
                    cG.style.right = T + "px";
                    break;
                default:
                    break
            }
            var cC = ["TL", "TR", "BL", "BR"];
            a1.dom.removeClass(this._container, "anchor" + cC[cD]);
            a1.dom.addClass(this._container, "anchor" + cC[cE])
        },
        getAnchor: function () {
            return this._opts.anchor
        },
        setOffset: function (T) {
            if (!(T instanceof aB)) {
                return
            }
            this._opts = this._opts || {
                printable: false
            };
            this._opts.offset = new aB(T.width, T.height);
            if (!this._container) {
                return
            }
            this.setAnchor(this._opts.anchor)
        },
        getOffset: function () {
            return this._opts.offset
        },
        getDom: function () {
            return this._container
        },
        show: function () {
            if (this._visible == true) {
                return
            }
            this._visible = true;
            if (this._container) {
                a1.dom.show(this._container)
            }
        },
        hide: function () {
            if (this._visible == false) {
                return
            }
            this._visible = false;
            if (this._container) {
                a1.dom.hide(this._container)
            }
        },
        isPrintable: function () {
            return !!this._opts.printable
        },
        isVisible: function () {
            if (!this._container && !this._map) {
                return false
            }
            return !!this._visible
        }
    });
    window.BMAP_ANCHOR_TOP_LEFT = 0;
    window.BMAP_ANCHOR_TOP_RIGHT = 1;
    window.BMAP_ANCHOR_BOTTOM_LEFT = 2;
    window.BMAP_ANCHOR_BOTTOM_RIGHT = 3;
    window.BMAP_NAVIGATION_CONTROL_LARGE = 0;
    window.BMAP_NAVIGATION_CONTROL_SMALL = 1;
    window.BMAP_NAVIGATION_CONTROL_PAN = 2;
    window.BMAP_NAVIGATION_CONTROL_ZOOM = 3;
    function J(T) {
        cg.call(this);
        T = T || {};
        this._opts = {
            printable: false,
            showZoomInfo: true
        };
        a1.object.extend(this._opts, T);
        this.defaultAnchor = BMAP_ANCHOR_TOP_LEFT;
        this.defaultOffset = new aB(10, 10);
        this.setAnchor(T.anchor);
        this.setType(T.type);
        this._asyncLoadCode()
    }
    a1.lang.inherits(J, cg, "NavigationControl");
    a1.extend(J.prototype, {
        initialize: function (T) {
            this._map = T;
            return this._container
        },
        setType: function (T) {
            if (aE(T) && T >= BMAP_NAVIGATION_CONTROL_LARGE && T <= BMAP_NAVIGATION_CONTROL_ZOOM) {
                this._opts.type = T
            } else {
                this._opts.type = BMAP_NAVIGATION_CONTROL_LARGE
            }
        },
        getType: function () {
            return this._opts.type
        },
        _asyncLoadCode: function () {
            var T = this;
            cr.load("control",
            function () {
                T._asyncDraw()
            })
        }
    });
    function ai(T) {
        cg.call(this);
        T = T || {};
        this._opts = {
            printable: false
        };
        a1.object.extend(this._opts, T);
        this._copyrightCollection = [];
        this.defaultAnchor = BMAP_ANCHOR_BOTTOM_LEFT;
        this.defaultOffset = new aB(5, 2);
        this.setAnchor(T.anchor);
        this._canShow = true;
        this.blockInfoWindow = false;
        this._asyncLoadCode()
    }
    a1.lang.inherits(ai, cg, "CopyrightControl");
    a1.object.extend(ai.prototype, {
        initialize: function (T) {
            this._map = T;
            return this._container
        },
        addCopyright: function (cD) {
            if (!cD || !aE(cD.id) || isNaN(cD.id)) {
                return
            }
            var T = {
                bounds: null,
                content: ""
            };
            for (var cC in cD) {
                T[cC] = cD[cC]
            }
            var cE = this.getCopyright(cD.id);
            if (cE) {
                for (var cF in T) {
                    cE[cF] = T[cF]
                }
            } else {
                this._copyrightCollection.push(T)
            }
        },
        getCopyright: function (cD) {
            for (var cC = 0,
            T = this._copyrightCollection.length; cC < T; cC++) {
                if (this._copyrightCollection[cC].id == cD) {
                    return this._copyrightCollection[cC]
                }
            }
        },
        getCopyrightCollection: function () {
            return this._copyrightCollection
        },
        removeCopyright: function (cD) {
            for (var cC = 0,
            T = this._copyrightCollection.length; cC < T; cC++) {
                if (this._copyrightCollection[cC].id == cD) {
                    r = this._copyrightCollection.splice(cC, 1);
                    cC--;
                    T = this._copyrightCollection.length
                }
            }
        },
        _asyncLoadCode: function () {
            var T = this;
            cr.load("control",
            function () {
                T._asyncDraw()
            })
        }
    });
    function cB(T) {
        cg.call(this);
        T = T || {};
        this._opts = {
            printable: false
        };
        this._opts = a1.extend(a1.extend(this._opts, {
            size: new aB(150, 150),
            padding: 8,
            isOpen: false,
            zoomInterval: 4
        }), T);
        this.defaultAnchor = BMAP_ANCHOR_BOTTOM_RIGHT;
        this.defaultOffset = new aB(0, 0);
        this._btnWidth = 15;
        this._btnHeight = 15;
        this.setAnchor(T.anchor);
        this.setSize(this._opts.size);
        this._asyncLoadCode()
    }
    a1.lang.inherits(cB, cg, "OverviewMapControl");
    a1.extend(cB.prototype, {
        initialize: function (T) {
            this._map = T;
            return this._container
        },
        setAnchor: function (T) {
            cg.prototype.setAnchor.call(this, T)
        },
        changeView: function () {
            this.changeView._running = true;
            this._opts.isOpen = !this._opts.isOpen;
            if (!this._container) {
                this.changeView._running = false
            }
        },
        setSize: function (T) {
            if (!(T instanceof aB)) {
                T = new aB(150, 150)
            }
            T.width = T.width > 0 ? T.width : 150;
            T.height = T.height > 0 ? T.height : 150;
            this._opts.size = T
        },
        getSize: function () {
            return this._opts.size
        },
        isOpen: function () {
            return this._opts.isOpen
        },
        _asyncLoadCode: function () {
            var T = this;
            cr.load("control",
            function () {
                T._asyncDraw()
            })
        }
    });
    function bC(T) {
        cg.call(this);
        T = T || {};
        this._opts = {
            printable: false
        };
        this._opts = a1.object.extend(a1.object.extend(this._opts, {
            color: "black",
            unit: "metric"
        }), T);
        this.defaultAnchor = BMAP_ANCHOR_BOTTOM_LEFT;
        this.defaultOffset = new aB(81, 18);
        this.setAnchor(T.anchor);
        this._units = {
            metric: {
                name: "metric",
                conv: 1,
                incon: 1000,
                u1: "\u7c73",
                u2: "\u516c\u91cc"
            },
            us: {
                name: "us",
                conv: 3.2808,
                incon: 5280,
                u1: "\u82f1\u5c3a",
                u2: "\u82f1\u91cc"
            }
        };
        if (!this._units[this._opts.unit]) {
            this._opts.unit = "metric"
        }
        this._scaleText = null;
        this._numberArray = {};
        this._asyncLoadCode()
    }
    window.BMAP_UNIT_METRIC = "metric";
    window.BMAP_UNIT_IMPERIAL = "us";
    a1.lang.inherits(bC, cg, "ScaleControl");
    a1.object.extend(bC.prototype, {
        initialize: function (T) {
            this._map = T;
            return this._container
        },
        setColor: function (T) {
            this._opts.color = T + ""
        },
        getColor: function () {
            return this._opts.color
        },
        setUnit: function (T) {
            this._opts.unit = this._units[T] && this._units[T].name || this._opts.unit
        },
        getUnit: function () {
            return this._opts.unit
        },
        _asyncLoadCode: function () {
            var T = this;
            cr.load("control",
            function () {
                T._asyncDraw()
            })
        }
    });
    window.BMAP_MAPTYPE_CONTROL_HORIZONTAL = 0;
    window.BMAP_MAPTYPE_CONTROL_DROPDOWN = 1;
    function aF(T) {
        cg.call(this);
        T = T || {};
        this._opts = {
            printable: false,
            mapTypes: [BMAP_NORMAL_MAP, BMAP_SATELLITE_MAP, BMAP_HYBRID_MAP, BMAP_PERSPECTIVE_MAP],
            type: BMAP_MAPTYPE_CONTROL_HORIZONTAL
        };
        this.defaultAnchor = BMAP_ANCHOR_TOP_RIGHT;
        this.defaultOffset = new aB(10, 10);
        this.setAnchor(T.anchor);
        this._opts = a1.extend(a1.extend(this._opts, {
            offset: this.defaultOffset,
            enableSwitch: true
        }), T);
        if (aS(T.mapTypes)) {
            this._opts.mapTypes = T.mapTypes.slice(0)
        }
        this._asyncLoadCode()
    }
    a1.lang.inherits(aF, cg, "MapTypeControl");
    a1.object.extend(aF.prototype, {
        initialize: function (T) {
            this._map = T;
            return this._container
        },
        _asyncLoadCode: function () {
            var T = this;
            cr.load("control",
            function () {
                T._asyncDraw()
            })
        }
    });
    function cq(cC) {
        a1.lang.Class.call(this);
        this._opts = {
            container: null,
            cursor: "default"
        };
        this._opts = a1.extend(this._opts, cC);
        this._type = "contextmenu";
        this._map = null;
        this._container;
        this._shadow;
        this._left = 0;
        this._top = 0;
        this._items = [];
        this._rItems = [];
        this._dividers = [];
        this.curPixel = null;
        this.curPoint = null;
        this._isOpen = false;
        var T = this;
        cr.load("menu",
        function () {
            T._draw()
        })
    }
    a1.lang.inherits(cq, a1.lang.Class, "ContextMenu");
    a1.object.extend(cq.prototype, {
        initialize: function (cC, T) {
            this._map = cC;
            this._overlay = T || null
        },
        remove: function () {
            this._map = this._overlay = null
        },
        addItem: function (cD) {
            if (!cD || cD._type != "menuitem" || cD._text == "" || cD._width <= 0) {
                return
            }
            for (var cC = 0,
            T = this._items.length; cC < T; cC++) {
                if (this._items[cC] === cD) {
                    return
                }
            }
            this._items.push(cD);
            this._rItems.push(cD)
        },
        removeItem: function (cD) {
            if (!cD || cD._type != "menuitem") {
                return
            }
            for (var cC = 0,
            T = this._items.length; cC < T; cC++) {
                if (this._items[cC] === cD) {
                    this._items[cC].remove();
                    this._items.splice(cC, 1);
                    T--
                }
            }
            for (var cC = 0,
            T = this._rItems.length; cC < T; cC++) {
                if (this._rItems[cC] === cD) {
                    this._rItems[cC].remove();
                    this._rItems.splice(cC, 1);
                    T--
                }
            }
        },
        addSeparator: function () {
            this._items.push({
                _type: "divider",
                _dIndex: this._dividers.length
            });
            this._dividers.push({
                dom: null
            })
        },
        removeSeparator: function (cC) {
            if (!this._dividers[cC]) {
                return
            }
            for (var cD = 0,
            T = this._items.length; cD < T; cD++) {
                if (this._items[cD] && this._items[cD]._type == "divider" && this._items[cD]._dIndex == cC) {
                    this._items.splice(cD, 1);
                    T--
                }
                if (this._items[cD] && this._items[cD]._type == "divider" && this._items[cD]._dIndex > cC) {
                    this._items[cD]._dIndex--
                }
            }
            this._dividers.splice(cC, 1)
        },
        getDom: function () {
            return this._container
        },
        show: function () {
            if (this._isOpen == true) {
                return
            }
            this._isOpen = true
        },
        hide: function () {
            if (this._isOpen == false) {
                return
            }
            this._isOpen = false
        },
        setCursor: function (T) {
            if (!T) {
                return
            }
            this._opts.cursor = T
        },
        getItem: function (T) {
            return this._rItems[T]
        }
    });
    function a7(cD, cE, cC) {
        if (!cD || !G(cE)) {
            return
        }
        a1.lang.Class.call(this);
        this._opts = {
            width: 100,
            id: ""
        };
        cC = cC || {};
        this._opts.width = (cC.width * 1) ? cC.width : 100;
        this._opts.id = cC.id ? cC.id : "";
        this._text = cD + "";
        this._callback = cE;
        this._map = null;
        this._type = "menuitem";
        this._contextmenu = null;
        this._container = null;
        this._enabled = true;
        var T = this;
        cr.load("menu",
        function () {
            T._draw()
        })
    }
    a1.lang.inherits(a7, a1.lang.Class, "MenuItem");
    a1.object.extend(a7.prototype, {
        initialize: function (T, cC) {
            this._map = T;
            this._contextmenu = cC
        },
        remove: function () {
            this._contextmenu = null;
            this._map = null
        },
        setText: function (T) {
            if (!T) {
                return
            }
            this._text = T + ""
        },
        getDom: function () {
            return this._container
        },
        enable: function () {
            this._enabled = true
        },
        disable: function () {
            this._enabled = false
        }
    });
    function bF(T, cC) {
        if (T && !cC) {
            cC = T
        }
        this._sw = this._ne = null;
        this._swLng = this._swLat = null;
        this._neLng = this._neLat = null;
        if (T) {
            this._sw = new b4(T.lng, T.lat);
            this._ne = new b4(cC.lng, cC.lat);
            this._swLng = T.lng;
            this._swLat = T.lat;
            this._neLng = cC.lng;
            this._neLat = cC.lat
        }
    }
    a1.object.extend(bF.prototype, {
        isEmpty: function () {
            return !this._sw || !this._ne
        },
        equals: function (T) {
            if (!(T instanceof bF) || this.isEmpty()) {
                return false
            }
            return this.getSouthWest().equals(T.getSouthWest()) && this.getNorthEast().equals(T.getNorthEast())
        },
        getSouthWest: function () {
            return this._sw
        },
        getNorthEast: function () {
            return this._ne
        },
        containsBounds: function (T) {
            if (!(T instanceof bF) || this.isEmpty() || T.isEmpty()) {
                return false
            }
            return (T._swLng > this._swLng && T._neLng < this._neLng && T._swLat > this._swLat && T._neLat < this._neLat)
        },
        getCenter: function () {
            if (this.isEmpty()) {
                return null
            }
            return new b4((this._swLng + this._neLng) / 2, (this._swLat + this._neLat) / 2)
        },
        intersects: function (cD) {
            if (!(cD instanceof bF)) {
                return null
            }
            if (Math.max(cD._swLng, cD._neLng) < Math.min(this._swLng, this._neLng) || Math.min(cD._swLng, cD._neLng) > Math.max(this._swLng, this._neLng) || Math.max(cD._swLat, cD._neLat) < Math.min(this._swLat, this._neLat) || Math.min(cD._swLat, cD._neLat) > Math.max(this._swLat, this._neLat)) {
                return null
            }
            var cF = Math.max(this._swLng, cD._swLng);
            var cC = Math.min(this._neLng, cD._neLng);
            var cE = Math.max(this._swLat, cD._swLat);
            var T = Math.min(this._neLat, cD._neLat);
            return new bF(new b4(cF, cE), new b4(cC, T))
        },
        containsPoint: function (T) {
            if (!(T instanceof b4) || this.isEmpty()) {
                return false
            }
            return (T.lng >= this._swLng && T.lng <= this._neLng && T.lat >= this._swLat && T.lat <= this._neLat)
        },
        extend: function (T) {
            if (!(T instanceof b4)) {
                return
            }
            var cC = T.lng,
            cD = T.lat;
            if (!this._sw) {
                this._sw = new b4(0, 0)
            }
            if (!this._ne) {
                this._ne = new b4(0, 0)
            }
            if (!this._swLng || this._swLng > cC) {
                this._sw.lng = this._swLng = cC
            }
            if (!this._neLng || this._neLng < cC) {
                this._ne.lng = this._neLng = cC
            }
            if (!this._swLat || this._swLat > cD) {
                this._sw.lat = this._swLat = cD
            }
            if (!this._neLat || this._neLat < cD) {
                this._ne.lat = this._neLat = cD
            }
        },
        toSpan: function () {
            if (this.isEmpty()) {
                return new b4(0, 0)
            }
            return new b4(Math.abs(this._neLng - this._swLng), Math.abs(this._neLat - this._swLat))
        }
    });
    function b4(T, cC) {
        if (isNaN(T)) {
            T = bN(T);
            T = isNaN(T) ? 0 : T
        }
        if (bV(T)) {
            T = parseFloat(T)
        }
        if (isNaN(cC)) {
            cC = bN(cC);
            cC = isNaN(cC) ? 0 : cC
        }
        if (bV(cC)) {
            cC = parseFloat(cC)
        }
        this.lng = T;
        this.lat = cC
    }
    b4.isInRange = function (T) {
        return T && T.lng <= 180 && T.lng >= -180 && T.lat <= 74 && T.lat >= -74
    };
    b4.prototype.equals = function (T) {
        return T && this.lat == T.lat && this.lng == T.lng
    };
    function a6() { }
    a6.prototype.lngLatToPoint = function () {
        throw "lngLatToPoint\u65b9\u6cd5\u672a\u5b9e\u73b0"
    };
    a6.prototype.pointToLngLat = function () {
        throw "pointToLngLat\u65b9\u6cd5\u672a\u5b9e\u73b0"
    };
    function bX() { }
    a1.extend(bX, {
        num: {
            bj: {
                num: Math.sin(Math.PI / 4),
                num2: Math.sin(Math.PI / 6)
            },
            gz: {
                num: Math.sin(Math.PI / 4),
                num2: Math.sin(Math.PI / 4)
            },
            sz: {
                num: Math.sin(Math.PI / 4),
                num2: Math.sin(Math.PI / 4)
            },
            sh: {
                num: Math.sin(Math.PI / 4),
                num2: Math.sin(Math.PI / 4)
            }
        },
        correct_pts: {
            bj: [{
                j: 116.305687,
                w: 39.990912,
                utm_x: 12947230.73,
                utm_y: 4836903.65,
                x: 630412,
                y: 547340
            },
            {
                j: 116.381837,
                w: 40.000198,
                utm_x: 12955707.8,
                utm_y: 4838247.62,
                x: 667412,
                y: 561832
            },
            {
                j: 116.430651,
                w: 39.995216,
                utm_x: 12961141.81,
                utm_y: 4837526.55,
                x: 686556,
                y: 573372
            },
            {
                j: 116.474111,
                w: 39.976323,
                utm_x: 12965979.81,
                utm_y: 4834792.55,
                x: 697152,
                y: 586816
            },
            {
                j: 116.280328,
                w: 39.953159,
                utm_x: 12944407.75,
                utm_y: 4831441.53,
                x: 603272,
                y: 549976
            },
            {
                j: 116.316117,
                w: 39.952496,
                utm_x: 12948391.8,
                utm_y: 4831345.64,
                x: 618504,
                y: 557872
            },
            {
                j: 116.350477,
                w: 39.938107,
                utm_x: 12952216.78,
                utm_y: 4829264.65,
                x: 627044,
                y: 568220
            },
            {
                j: 116.432025,
                w: 39.947158,
                utm_x: 12961294.76,
                utm_y: 4830573.59,
                x: 666280,
                y: 584016
            },
            {
                j: 116.46873,
                w: 39.949516,
                utm_x: 12965380.79,
                utm_y: 4830914.63,
                x: 683328,
                y: 591444
            },
            {
                j: 116.280077,
                w: 39.913823,
                utm_x: 12944379.8,
                utm_y: 4825753.62,
                x: 586150,
                y: 558552
            },
            {
                j: 116.308625,
                w: 39.91374,
                utm_x: 12947557.79,
                utm_y: 4825741.62,
                x: 598648,
                y: 564732
            },
            {
                j: 116.369853,
                w: 39.912979,
                utm_x: 12954373.73,
                utm_y: 4825631.62,
                x: 624561,
                y: 578039
            },
            {
                j: 116.433552,
                w: 39.914694,
                utm_x: 12961464.75,
                utm_y: 4825879.53,
                x: 652972,
                y: 591348
            },
            {
                j: 116.457034,
                w: 39.914273,
                utm_x: 12964078.78,
                utm_y: 4825818.67,
                x: 663028,
                y: 596444
            },
            {
                j: 116.490927,
                w: 39.914127,
                utm_x: 12967851.77,
                utm_y: 4825797.57,
                x: 677968,
                y: 604188
            },
            {
                j: 116.483839,
                w: 39.877198,
                utm_x: 12967062.73,
                utm_y: 4820460.67,
                x: 658596,
                y: 610312
            },
            {
                j: 116.405777,
                w: 39.864461,
                utm_x: 12958372.82,
                utm_y: 4818620.62,
                x: 619256,
                y: 596088
            },
            {
                j: 116.35345,
                w: 39.859774,
                utm_x: 12952547.74,
                utm_y: 4817943.6,
                x: 594633,
                y: 585851
            },
            {
                j: 116.403818,
                w: 39.9141,
                utm_x: 12958154.74,
                utm_y: 4825793.66,
                x: 639699,
                y: 585226
            },
            {
                j: 116.318111,
                w: 39.891101,
                utm_x: 12948613.78,
                utm_y: 4822469.56,
                x: 592856,
                y: 571480
            },
            {
                j: 116.413047,
                w: 39.907238,
                utm_x: 12959182.12,
                utm_y: 4824801.76,
                x: 640680,
                y: 588704
            },
            {
                j: 116.390843,
                w: 39.906113,
                utm_x: 12956710.35,
                utm_y: 4824639.16,
                x: 630620,
                y: 584108
            },
            {
                j: 116.446527,
                w: 39.899438,
                utm_x: 12962909.14,
                utm_y: 4823674.4,
                x: 651752,
                y: 597416
            },
            {
                j: 116.388665,
                w: 39.95527,
                utm_x: 12956467.9,
                utm_y: 4831746.87,
                x: 650656,
                y: 572800
            },
            {
                j: 116.398343,
                w: 39.939704,
                utm_x: 12957545.26,
                utm_y: 4829495.6,
                x: 648036,
                y: 578452
            },
            {
                j: 116.355101,
                w: 39.973581,
                utm_x: 12952731.53,
                utm_y: 4834395.82,
                x: 643268,
                y: 560944
            },
            {
                j: 116.380727,
                w: 39.88464,
                utm_x: 12955584.23,
                utm_y: 4821535.94,
                x: 616920,
                y: 586496
            },
            {
                j: 116.360843,
                w: 39.946452,
                utm_x: 12953370.73,
                utm_y: 4830471.48,
                x: 635293,
                y: 568765
            },
            {
                j: 116.340955,
                w: 39.973421,
                utm_x: 12951156.79,
                utm_y: 4834372.67,
                x: 638420,
                y: 558632
            },
            {
                j: 116.322585,
                w: 40.023941,
                utm_x: 12949111.83,
                utm_y: 4841684.79,
                x: 652135,
                y: 543802
            },
            {
                j: 116.356486,
                w: 39.883341,
                utm_x: 12952885.71,
                utm_y: 4821348.24,
                x: 606050,
                y: 581443
            },
            {
                j: 116.339592,
                w: 39.992259,
                utm_x: 12951005.06,
                utm_y: 4837098.59,
                x: 645664,
                y: 554400
            },
            {
                j: 116.3778,
                w: 39.86392,
                utm_x: 12955258.4,
                utm_y: 4818542.48,
                x: 606848,
                y: 590328
            },
            {
                j: 116.377354,
                w: 39.964124,
                utm_x: 12955208.75,
                utm_y: 4833027.64,
                x: 649911,
                y: 568581
            },
            {
                j: 116.361837,
                w: 39.963897,
                utm_x: 12953481.39,
                utm_y: 4832994.8,
                x: 643286,
                y: 565175
            },
            {
                j: 116.441397,
                w: 39.939403,
                utm_x: 12962338.06,
                utm_y: 4829452.07,
                x: 666772,
                y: 587728
            },
            {
                j: 116.359176,
                w: 40.006631,
                utm_x: 12953185.16,
                utm_y: 4839178.78,
                x: 660440,
                y: 555411
            }],
            sz: [{
                j: 113.88099,
                w: 22.58884,
                utm_x: 12677311.76,
                utm_y: 2565810.52,
                x: 569078,
                y: 532290
            },
            {
                j: 113.902002,
                w: 22.566098,
                utm_x: 12679650.83,
                utm_y: 2563084.58,
                x: 568318,
                y: 545457
            },
            {
                j: 113.869843,
                w: 22.577711,
                utm_x: 12676070.87,
                utm_y: 2564476.5,
                x: 561115,
                y: 532494
            },
            {
                j: 113.943387,
                w: 22.555192,
                utm_x: 12684257.84,
                utm_y: 2561777.5,
                x: 579437,
                y: 558427
            },
            {
                j: 113.899505,
                w: 22.577052,
                utm_x: 12679372.86,
                utm_y: 2564397.51,
                x: 571923,
                y: 540181
            },
            {
                j: 113.900376,
                w: 22.596431,
                utm_x: 12679469.82,
                utm_y: 2566720.51,
                x: 580142,
                y: 535463
            },
            {
                j: 113.92101,
                w: 22.528931,
                utm_x: 12681766.81,
                utm_y: 2558630.58,
                x: 560296,
                y: 559780
            },
            {
                j: 113.919672,
                w: 22.517839,
                utm_x: 12681617.86,
                utm_y: 2557301.57,
                x: 555296,
                y: 562549
            },
            {
                j: 113.938716,
                w: 22.505569,
                utm_x: 12683737.86,
                utm_y: 2555831.55,
                x: 557349,
                y: 571072
            },
            {
                j: 113.919203,
                w: 22.483494,
                utm_x: 12681565.66,
                utm_y: 2553187.17,
                x: 540853,
                y: 572118
            },
            {
                j: 113.942875,
                w: 22.492046,
                utm_x: 12684200.84,
                utm_y: 2554211.57,
                x: 553296,
                y: 575994
            },
            {
                j: 113.9567,
                w: 22.530183,
                utm_x: 12685739.85,
                utm_y: 2558780.59,
                x: 573378,
                y: 568442
            },
            {
                j: 113.989102,
                w: 22.52697,
                utm_x: 12689346.86,
                utm_y: 2558395.61,
                x: 584796,
                y: 578728
            },
            {
                j: 114.015467,
                w: 22.533746,
                utm_x: 12692281.83,
                utm_y: 2559207.53,
                x: 597126,
                y: 584075
            },
            {
                j: 113.972977,
                w: 22.55702,
                utm_x: 12687551.81,
                utm_y: 2561996.58,
                x: 591204,
                y: 565924
            },
            {
                j: 113.990368,
                w: 22.561133,
                utm_x: 12689487.79,
                utm_y: 2562489.51,
                x: 599240,
                y: 569528
            },
            {
                j: 114.143745,
                w: 22.580535,
                utm_x: 12706561.83,
                utm_y: 2564815,
                x: 663830,
                y: 605622
            },
            {
                j: 114.150374,
                w: 22.557704,
                utm_x: 12707299.77,
                utm_y: 2562078.56,
                x: 657016,
                y: 613828
            },
            {
                j: 114.106905,
                w: 22.541858,
                utm_x: 12702460.77,
                utm_y: 2560179.58,
                x: 634284,
                y: 606528
            },
            {
                j: 114.083927,
                w: 22.535065,
                utm_x: 12699902.85,
                utm_y: 2559365.58,
                x: 623132,
                y: 602096
            },
            {
                j: 114.049584,
                w: 22.517997,
                utm_x: 12696079.76,
                utm_y: 2557320.5,
                x: 603390,
                y: 597564
            },
            {
                j: 114.056304,
                w: 22.542425,
                utm_x: 12696827.84,
                utm_y: 2560247.52,
                x: 615980,
                y: 592534
            },
            {
                j: 114.051552,
                w: 22.551321,
                utm_x: 12696298.84,
                utm_y: 2561313.59,
                x: 617887,
                y: 588719
            },
            {
                j: 114.096377,
                w: 22.559064,
                utm_x: 12701288.79,
                utm_y: 2562241.55,
                x: 637568,
                y: 598739
            },
            {
                j: 114.135858,
                w: 22.575851,
                utm_x: 12705683.84,
                utm_y: 2564253.55,
                x: 659024,
                y: 604806
            },
            {
                j: 114.092029,
                w: 22.575592,
                utm_x: 12700804.77,
                utm_y: 2564222.51,
                x: 642776,
                y: 592932
            },
            {
                j: 114.054795,
                w: 22.570617,
                utm_x: 12696659.85,
                utm_y: 2563626.21,
                x: 626988,
                y: 584142
            },
            {
                j: 114.03075,
                w: 22.553687,
                utm_x: 12693983.15,
                utm_y: 2561597.14,
                x: 611068,
                y: 582552
            },
            {
                j: 114.074153,
                w: 22.554124,
                utm_x: 12698814.8,
                utm_y: 2561649.51,
                x: 627380,
                y: 594008
            },
            {
                j: 113.926721,
                w: 22.546028,
                utm_x: 12682402.56,
                utm_y: 2560679.29,
                x: 569340,
                y: 556468
            },
            {
                j: 113.938125,
                w: 22.538296,
                utm_x: 12683672.07,
                utm_y: 2559752.74,
                x: 570548,
                y: 561748
            }],
            gz: [{
                j: 113.335098,
                w: 23.147289,
                utm_x: 12616542.68,
                utm_y: 2632892.7,
                x: 1129109,
                y: 1073920
            },
            {
                j: 113.320932,
                w: 23.146956,
                utm_x: 12614965.71,
                utm_y: 2632852.62,
                x: 1125620,
                y: 1071640
            },
            {
                j: 113.321435,
                w: 23.140119,
                utm_x: 12615021.7,
                utm_y: 2632029.65,
                x: 1124032,
                y: 1072882
            },
            {
                j: 113.321471,
                w: 23.119165,
                utm_x: 12615025.71,
                utm_y: 2629507.68,
                x: 1118932,
                y: 1076530
            },
            {
                j: 113.340201,
                w: 23.118616,
                utm_x: 12617110.75,
                utm_y: 2629441.61,
                x: 1123238,
                y: 1079667
            },
            {
                j: 113.358068,
                w: 23.116323,
                utm_x: 12619099.71,
                utm_y: 2629165.66,
                x: 1126968,
                y: 1083116
            },
            {
                j: 113.357529,
                w: 23.131271,
                utm_x: 12619039.71,
                utm_y: 2630964.68,
                x: 1130508,
                y: 1080440
            },
            {
                j: 113.365811,
                w: 23.150595,
                utm_x: 12619961.67,
                utm_y: 2633290.66,
                x: 1137205,
                y: 1078567
            },
            {
                j: 113.294145,
                w: 23.118467,
                utm_x: 12611983.76,
                utm_y: 2629423.68,
                x: 1112245,
                y: 1072043
            },
            {
                j: 113.28615,
                w: 23.121525,
                utm_x: 12611093.75,
                utm_y: 2629791.7,
                x: 1110993,
                y: 1070197
            },
            {
                j: 113.307152,
                w: 23.055497,
                utm_x: 12613431.71,
                utm_y: 2621847.21,
                x: 1100144,
                y: 1085123
            },
            {
                j: 113.333445,
                w: 23.052687,
                utm_x: 12616358.66,
                utm_y: 2621509.2,
                x: 1105784,
                y: 1089948
            },
            {
                j: 113.347476,
                w: 23.048755,
                utm_x: 12617920.6,
                utm_y: 2621036.24,
                x: 1108099,
                y: 1093064
            },
            {
                j: 113.385774,
                w: 23.036574,
                utm_x: 12622183.96,
                utm_y: 2619571.12,
                x: 1113850,
                y: 1101834
            },
            {
                j: 113.364185,
                w: 22.89798,
                utm_x: 12619780.66,
                utm_y: 2602910.64,
                x: 1073186,
                y: 1123374
            },
            {
                j: 113.404577,
                w: 22.906481,
                utm_x: 12624277.13,
                utm_y: 2603932.06,
                x: 1084888,
                y: 1128692
            },
            {
                j: 113.430856,
                w: 22.913156,
                utm_x: 12627202.52,
                utm_y: 2604734.12,
                x: 1092892,
                y: 1131761
            },
            {
                j: 113.384554,
                w: 22.933021,
                utm_x: 12622048.15,
                utm_y: 2607121.32,
                x: 1086975,
                y: 1120403
            },
            {
                j: 113.263566,
                w: 23.146333,
                utm_x: 12608579.68,
                utm_y: 2632777.63,
                x: 1111742,
                y: 1062098
            },
            {
                j: 113.239213,
                w: 23.152996,
                utm_x: 12605868.69,
                utm_y: 2633579.69,
                x: 1107616,
                y: 1056740
            },
            {
                j: 113.253865,
                w: 23.131628,
                utm_x: 12607499.76,
                utm_y: 2631007.65,
                x: 1105912,
                y: 1062966
            },
            {
                j: 113.240767,
                w: 23.088434,
                utm_x: 12606041.68,
                utm_y: 2625809.7,
                x: 1092270,
                y: 1068184
            },
            {
                j: 113.279628,
                w: 23.088284,
                utm_x: 12610367.72,
                utm_y: 2625791.65,
                x: 1101412,
                y: 1074883
            },
            {
                j: 113.462271,
                w: 23.107058,
                utm_x: 12630699.66,
                utm_y: 2628050.7,
                x: 1148752,
                y: 1101736
            },
            {
                j: 113.401618,
                w: 23.052957,
                utm_x: 12623947.73,
                utm_y: 2621541.68,
                x: 1121925,
                y: 1101535
            },
            {
                j: 113.422504,
                w: 23.05905,
                utm_x: 12626272.77,
                utm_y: 2622274.61,
                x: 1128470,
                y: 1104049
            },
            {
                j: 113.362506,
                w: 23.107149,
                utm_x: 12619593.75,
                utm_y: 2628061.65,
                x: 1125835,
                y: 1085505
            },
            {
                j: 113.419629,
                w: 23.143176,
                utm_x: 12625952.73,
                utm_y: 2632397.61,
                x: 1148133,
                y: 1089052
            },
            {
                j: 113.23315,
                w: 23.062251,
                utm_x: 12605193.75,
                utm_y: 2622659.67,
                x: 1084184,
                y: 1071368
            },
            {
                j: 113.314525,
                w: 23.101412,
                utm_x: 12614252.48,
                utm_y: 2627371.29,
                x: 1113011,
                y: 1078426
            },
            {
                j: 113.307947,
                w: 23.131369,
                utm_x: 12613520.21,
                utm_y: 2630976.47,
                x: 1118622,
                y: 1072198
            }],
            sh: [{
                j: 121.524411,
                w: 31.245875,
                utm_x: 13528182.75,
                utm_y: 3642354.51,
                x: 1086581,
                y: 1065728
            },
            {
                j: 121.419229,
                w: 31.244887,
                utm_x: 13516473.81,
                utm_y: 3642226.51,
                x: 1032616,
                y: 1029148
            },
            {
                j: 121.405637,
                w: 31.237871,
                utm_x: 13514960.74,
                utm_y: 3641317.54,
                x: 1022724,
                y: 1027244
            },
            {
                j: 121.415348,
                w: 31.222879,
                utm_x: 13516041.78,
                utm_y: 3639375.47,
                x: 1018548,
                y: 1036980
            },
            {
                j: 121.422561,
                w: 31.224261,
                utm_x: 13516844.73,
                utm_y: 3639554.48,
                x: 1022976,
                y: 1038908
            },
            {
                j: 121.412581,
                w: 31.204148,
                utm_x: 13515733.75,
                utm_y: 3636949.48,
                x: 1006568,
                y: 1043696
            },
            {
                j: 121.443025,
                w: 31.206202,
                utm_x: 13519122.8,
                utm_y: 3637215.49,
                x: 1022656,
                y: 1053704
            },
            {
                j: 121.524061,
                w: 31.246917,
                utm_x: 13528143.79,
                utm_y: 3642489.52,
                x: 1082052,
                y: 1064124
            },
            {
                j: 121.529343,
                w: 31.217769,
                utm_x: 13528731.78,
                utm_y: 3638713.59,
                x: 1072696,
                y: 1079064
            },
            {
                j: 121.530268,
                w: 31.210341,
                utm_x: 13528834.75,
                utm_y: 3637751.53,
                x: 1068748,
                y: 1082416
            },
            {
                j: 121.511601,
                w: 31.227303,
                utm_x: 13526756.73,
                utm_y: 3639948.53,
                x: 1069276,
                y: 1068716
            },
            {
                j: 121.4966,
                w: 31.243614,
                utm_x: 13525086.81,
                utm_y: 3642061.58,
                x: 1071220,
                y: 1056805
            },
            {
                j: 121.485021,
                w: 31.26138,
                utm_x: 13523797.82,
                utm_y: 3644363.54,
                x: 1075708,
                y: 1045540
            },
            {
                j: 121.465114,
                w: 31.278803,
                utm_x: 13521581.76,
                utm_y: 3646621.48,
                x: 1073740,
                y: 1031268
            },
            {
                j: 121.454784,
                w: 31.266566,
                utm_x: 13520431.82,
                utm_y: 3645035.58,
                x: 1063591,
                y: 1033191
            },
            {
                j: 121.46851,
                w: 31.24951,
                utm_x: 13521959.81,
                utm_y: 3642825.48,
                x: 1060200,
                y: 1044520
            },
            {
                j: 121.446384,
                w: 31.248422,
                utm_x: 13519496.73,
                utm_y: 3642684.51,
                x: 1048784,
                y: 1037750
            },
            {
                j: 121.509499,
                w: 31.246469,
                utm_x: 13526522.73,
                utm_y: 3642431.47,
                x: 1079309,
                y: 1060105
            },
            {
                j: 121.481643,
                w: 31.283943,
                utm_x: 13523421.78,
                utm_y: 3647287.68,
                x: 1087096,
                y: 1035304
            },
            {
                j: 121.508054,
                w: 31.280609,
                utm_x: 13526361.87,
                utm_y: 3646855.56,
                x: 1098432,
                y: 1045648
            },
            {
                j: 121.493854,
                w: 31.19121,
                utm_x: 13524781.12,
                utm_y: 3635274.07,
                x: 1039624,
                y: 1077288
            },
            {
                j: 121.500079,
                w: 31.185541,
                utm_x: 13525474.09,
                utm_y: 3634540.04,
                x: 1039960,
                y: 1081640
            },
            {
                j: 121.484482,
                w: 31.202846,
                utm_x: 13523737.82,
                utm_y: 3636780.87,
                x: 1041388,
                y: 1069232
            },
            {
                j: 121.480877,
                w: 31.189587,
                utm_x: 13523336.51,
                utm_y: 3635063.92,
                x: 1032484,
                y: 1073640
            },
            {
                j: 121.502652,
                w: 31.195209,
                utm_x: 13525760.52,
                utm_y: 3635791.9,
                x: 1046384,
                y: 1078728
            }]
        },
        getLnglatIndex: function (cE, cI, cH) {
            var cD = 0;
            var cC = 0;
            var cJ = 10000000,
            cG = 1000000000;
            for (var cF = 0; cF < this.correct_pts[cE].length; cF++) {
                var T = this.getDis(this.correct_pts[cE][cF].x, this.correct_pts[cE][cF].y, cI, cH);
                if (T < cG) {
                    if (T < cJ) {
                        cG = cJ;
                        cJ = T;
                        cC = cD;
                        cD = cF
                    } else {
                        sedMinDis = T;
                        cC = cF
                    }
                }
            }
            return {
                lt: cD,
                rb: cC
            }
        },
        getOMapIndex_mm: function (cE, cJ, cI) {
            var cD = 0;
            var cC = 0;
            var cH = 1294723000,
            cG = 1294723000;
            for (var cF = 0; cF < this.correct_pts[cE].length; cF++) {
                var T = this.getDis(this.correct_pts[cE][cF].utm_x, this.correct_pts[cE][cF].utm_y, cJ, cI);
                if (T < cG) {
                    if (T < cH) {
                        cG = cH;
                        cH = T;
                        cC = cD;
                        cD = cF
                    } else {
                        sedMinDis = T;
                        cC = cF
                    }
                }
            }
            return {
                lt: cD,
                rb: cC
            }
        },
        getDis: function (T, cE, cC, cD) {
            return Math.abs(T - cC) + Math.abs(cE - cD)
        },
        toMap: function (cE, T, cF) {
            var cC = (T - cF) * this.num[cE].num;
            var cD = (T + cF) * this.num[cE].num * this.num[cE].num2;
            return {
                x: cC,
                y: cD
            }
        },
        fromMap: function (cE, T, cF) {
            cF = cF / this.num[cE].num2;
            var cC = (T + cF) / (this.num[cE].num * 2);
            var cD = (cF - T) / (this.num[cE].num * 2);
            return {
                x: cC,
                y: cD
            }
        },
        getDgPix_mm: function (cF, cK, cG) {
            var cJ = this.fromMap(cF, this.correct_pts[cF][cK].x, this.correct_pts[cF][cK].y);
            var cH = this.fromMap(cF, this.correct_pts[cF][cG].x, this.correct_pts[cF][cG].y);
            var cP = cJ.x,
            cC = cJ.y;
            var cO = cH.x,
            T = cH.y;
            var cM = this.correct_pts[cF][cK].utm_x,
            cE = this.correct_pts[cF][cK].utm_y;
            var cI = this.correct_pts[cF][cG].utm_x,
            cD = this.correct_pts[cF][cG].utm_y;
            var cN = Math.abs((cI - cM) * 100000 / (cO - cP));
            var cL = Math.abs((cD - cE) * 100000 / (T - cC));
            return {
                j: cN,
                w: cL,
                x: 100000 / cN,
                y: 100000 / cL
            }
        },
        getPx_mm: function (cS, cO, cN, cF, cE) {
            var cD = this.correct_pts[cS][cF];
            var T = this.correct_pts[cS][cF];
            var cL = this.getDgPix_mm(cS, cF, cE);
            var cH = this.fromMap(cS, cD.x, cD.y);
            var cG = T.utm_x,
            cU = T.utm_y;
            var cT = cO,
            cM = cN;
            var cR = cH.x;
            var cC = cH.y;
            var cJ = cT - cG,
            cQ = cM - cU;
            var cK = cJ * cL.x + cR;
            var cI = -cQ * cL.y + cC;
            var cP = this.toMap(cS, cK, cI);
            return cP
        },
        getJw_mm: function (cQ, cL, cK, cG, cF) {
            var cJ = this.correct_pts[cQ][cG];
            var cC = this.correct_pts[cQ][cG];
            var cM = this.getDgPix_mm(cQ, cG, cF);
            var cO = this.fromMap(cQ, cL, cK);
            var cE = this.fromMap(cQ, cJ.x, cJ.y);
            var cH = cC.utm_x,
            cR = cC.utm_y;
            var cP = cE.x;
            var cD = cE.y;
            var cS = cO.x - cP,
            cN = cD - cO.y;
            var cI = cS / cM.x + cH;
            var T = cN / cM.y + cR;
            return {
                lng: cI,
                lat: T
            }
        },
        getOMap_pts: function (cC, T) {
            return this.getOMap_index(cC, T.lng, T.lat, T.lt, T.rb)
        },
        getMapJw_pts: function (cC, T) {
            return this.getMapJw_index(cC, T.lng, 9998336 - T.lat, T.lt, T.rb)
        },
        getOMap_index: function (cH, cG, cF, T, cE) {
            if (!T || !cE) {
                var cC = this.getOMapIndex_mm(cH, cG, cF)
            } else {
                var cC = {
                    lt: T,
                    rb: cE
                }
            }
            var cD = this.getPx_mm(cH, cG, cF, cC.lt, cC.rb);
            return {
                x: Math.floor(cD.x),
                y: 9998336 - Math.floor(cD.y),
                lt: cC.lt,
                rb: cC.rb
            }
        },
        getMapJw_index: function (cG, cD, cH, cC, cF) {
            if (!cC || !cF) {
                var cE = this.getLnglatIndex(cG, cD, cH)
            } else {
                var cE = {
                    lt: cC,
                    rb: cF
                }
            }
            var T = this.getJw_mm(cG, cD, cH, cE.lt, cE.rb);
            return {
                lng: T.lng,
                lat: T.lat,
                lt: cE.lt,
                rb: cE.rb
            }
        }
    });
    function a3() { }
    a3.prototype = new a6();
    a1.extend(a3, {
        EARTHRADIUS: 6370996.81,
        MCBAND: [12890594.86, 8362377.87, 5591021, 3481989.83, 1678043.12, 0],
        LLBAND: [75, 60, 45, 30, 15, 0],
        MC2LL: [[1.410526172116255e-8, 0.00000898305509648872, -1.9939833816331, 200.9824383106796, -187.2403703815547, 91.6087516669843, -23.38765649603339, 2.57121317296198, -0.03801003308653, 17337981.2], [-7.435856389565537e-9, 0.000008983055097726239, -0.78625201886289, 96.32687599759846, -1.85204757529826, -59.36935905485877, 47.40033549296737, -16.50741931063887, 2.28786674699375, 10260144.86], [-3.030883460898826e-8, 0.00000898305509983578, 0.30071316287616, 59.74293618442277, 7.357984074871, -25.38371002664745, 13.45380521110908, -3.29883767235584, 0.32710905363475, 6856817.37], [-1.981981304930552e-8, 0.000008983055099779535, 0.03278182852591, 40.31678527705744, 0.65659298677277, -4.44255534477492, 0.85341911805263, 0.12923347998204, -0.04625736007561, 4482777.06], [3.09191371068437e-9, 0.000008983055096812155, 0.00006995724062, 23.10934304144901, -0.00023663490511, -0.6321817810242, -0.00663494467273, 0.03430082397953, -0.00466043876332, 2555164.4], [2.890871144776878e-9, 0.000008983055095805407, -3.068298e-8, 7.47137025468032, -0.00000353937994, -0.02145144861037, -0.00001234426596, 0.00010322952773, -0.00000323890364, 826088.5]],
        LL2MC: [[-0.0015702102444, 111320.7020616939, 1704480524535203, -10338987376042340, 26112667856603880, -35149669176653700, 26595700718403920, -10725012454188240, 1800819912950474, 82.5], [0.0008277824516172526, 111320.7020463578, 647795574.6671607, -4082003173.641316, 10774905663.51142, -15171875531.51559, 12053065338.62167, -5124939663.577472, 913311935.9512032, 67.5], [0.00337398766765, 111320.7020202162, 4481351.045890365, -23393751.19931662, 79682215.47186455, -115964993.2797253, 97236711.15602145, -43661946.33752821, 8477230.501135234, 52.5], [0.00220636496208, 111320.7020209128, 51751.86112841131, 3796837.749470245, 992013.7397791013, -1221952.21711287, 1340652.697009075, -620943.6990984312, 144416.9293806241, 37.5], [-0.0003441963504368392, 111320.7020576856, 278.2353980772752, 2485758.690035394, 6070.750963243378, 54821.18345352118, 9540.606633304236, -2710.55326746645, 1405.483844121726, 22.5], [-0.0003218135878613132, 111320.7020701615, 0.00369383431289, 823725.6402795718, 0.46104986909093, 2351.343141331292, 1.58060784298199, 8.77738589078284, 0.37238884252424, 7.45]],
        getDistanceByMC: function (cG, cE) {
            if (!cG || !cE) {
                return 0
            }
            var cC, cF, T, cD;
            cG = this.convertMC2LL(cG);
            if (!cG) {
                return 0
            }
            cC = this.toRadians(cG.lng);
            cF = this.toRadians(cG.lat);
            cE = this.convertMC2LL(cE);
            if (!cE) {
                return 0
            }
            T = this.toRadians(cE.lng);
            cD = this.toRadians(cE.lat);
            return this.getDistance(cC, T, cF, cD)
        },
        getDistanceByLL: function (cG, cE) {
            if (!cG || !cE) {
                return 0
            }
            cG.lng = this.getLoop(cG.lng, -180, 180);
            cG.lat = this.getRange(cG.lat, -74, 74);
            cE.lng = this.getLoop(cE.lng, -180, 180);
            cE.lat = this.getRange(cE.lat, -74, 74);
            var cC, T, cF, cD;
            cC = this.toRadians(cG.lng);
            cF = this.toRadians(cG.lat);
            T = this.toRadians(cE.lng);
            cD = this.toRadians(cE.lat);
            return this.getDistance(cC, T, cF, cD)
        },
        convertMC2LL: function (cC) {
            var cD, cF;
            cD = new b4(Math.abs(cC.lng), Math.abs(cC.lat));
            for (var cE = 0; cE < this.MCBAND.length; cE++) {
                if (cD.lat >= this.MCBAND[cE]) {
                    cF = this.MC2LL[cE];
                    break
                }
            }
            var T = this.convertor(cC, cF);
            var cC = new b4(T.lng.toFixed(6), T.lat.toFixed(6));
            return cC
        },
        convertLL2MC: function (T) {
            var cC, cE;
            T.lng = this.getLoop(T.lng, -180, 180);
            T.lat = this.getRange(T.lat, -74, 74);
            cC = new b4(T.lng, T.lat);
            for (var cD = 0; cD < this.LLBAND.length; cD++) {
                if (cC.lat >= this.LLBAND[cD]) {
                    cE = this.LL2MC[cD];
                    break
                }
            }
            if (!cE) {
                for (var cD = this.LLBAND.length - 1; cD >= 0; cD--) {
                    if (cC.lat <= -this.LLBAND[cD]) {
                        cE = this.LL2MC[cD];
                        break
                    }
                }
            }
            var cF = this.convertor(T, cE);
            var T = new b4(cF.lng.toFixed(2), cF.lat.toFixed(2));
            return T
        },
        convertor: function (cD, cE) {
            if (!cD || !cE) {
                return
            }
            var T = cE[0] + cE[1] * Math.abs(cD.lng);
            var cC = Math.abs(cD.lat) / cE[9];
            var cF = cE[2] + cE[3] * cC + cE[4] * cC * cC + cE[5] * cC * cC * cC + cE[6] * cC * cC * cC * cC + cE[7] * cC * cC * cC * cC * cC + cE[8] * cC * cC * cC * cC * cC * cC;
            T *= (cD.lng < 0 ? -1 : 1);
            cF *= (cD.lat < 0 ? -1 : 1);
            return new b4(T, cF)
        },
        getDistance: function (cC, T, cE, cD) {
            return this.EARTHRADIUS * Math.acos((Math.sin(cE) * Math.sin(cD) + Math.cos(cE) * Math.cos(cD) * Math.cos(T - cC)))
        },
        toRadians: function (T) {
            return Math.PI * T / 180
        },
        toDegrees: function (T) {
            return (180 * T) / Math.PI
        },
        getRange: function (cD, cC, T) {
            if (cC != null) {
                cD = Math.max(cD, cC)
            }
            if (T != null) {
                cD = Math.min(cD, T)
            }
            return cD
        },
        getLoop: function (cD, cC, T) {
            while (cD > T) {
                cD -= T - cC
            }
            while (cD < cC) {
                cD += T - cC
            }
            return cD
        }
    });
    a1.extend(a3.prototype, {
        lngLatToMercator: function (T) {
            return a3.convertLL2MC(T)
        },
        lngLatToPoint: function (T) {
            var cC = a3.convertLL2MC(T);
            return new bn(cC.lng, cC.lat)
        },
        mercatorToLngLat: function (T) {
            return a3.convertMC2LL(T)
        },
        pointToLngLat: function (T) {
            var cC = new b4(T.x, T.y);
            return a3.convertMC2LL(cC)
        },
        pointToPixel: function (cC, cG, cF, cE, cH) {
            if (!cC) {
                return
            }
            cC = this.lngLatToMercator(cC, cH);
            var cD = this.getZoomUnits(cG);
            var T = Math.round((cC.lng - cF.lng) / cD + cE.width / 2);
            var cI = Math.round((cF.lat - cC.lat) / cD + cE.height / 2);
            return new bn(T, cI)
        },
        pixelToPoint: function (T, cJ, cF, cD, cC) {
            if (!T) {
                return
            }
            var cI = this.getZoomUnits(cJ);
            var cG = cF.lng + cI * (T.x - cD.width / 2);
            var cE = cF.lat - cI * (T.y - cD.height / 2);
            var cH = new b4(cG, cE);
            return this.mercatorToLngLat(cH, cC)
        },
        getZoomUnits: function (T) {
            return Math.pow(2, (18 - T))
        }
    });
    function cv() { }
    cv.prototype = new a3();
    a1.extend(cv.prototype, {
        lngLatToMercator: function (cC, T) {
            return this._convert2DTo3D(T, a3.convertLL2MC(cC))
        },
        mercatorToLngLat: function (cC, T) {
            return a3.convertMC2LL(this._convert3DTo2D(T, cC))
        },
        lngLatToPoint: function (cD, T) {
            var cC = this._convert2DTo3D(T, a3.convertLL2MC(cD));
            return new bn(cC.lng, cC.lat)
        },
        pointToLngLat: function (cC, T) {
            var cD = new b4(cC.x, cC.y);
            return a3.convertMC2LL(this._convert3DTo2D(T, cD))
        },
        _convert2DTo3D: function (cD, T) {
            var cC = bX.getOMap_pts(cD || "bj", T);
            return new b4(cC.x, cC.y)
        },
        _convert3DTo2D: function (cD, T) {
            var cC = bX.getMapJw_pts(cD || "bj", T);
            return new b4(cC.lng, cC.lat)
        },
        getZoomUnits: function (T) {
            return Math.pow(2, (20 - T))
        }
    });
    function bz() {
        this._type = "overlay"
    }
    a1.lang.inherits(bz, a1.lang.Class, "Overlay");
    bz.getZIndex = function (T) {
        T = T * 1;
        if (!T) {
            return 0
        }
        return (T * -100000) << 1
    };
    a1.extend(bz.prototype, {
        _i: function (T) {
            if (!this.domElement && G(this.initialize)) {
                this.domElement = this.initialize(T);
                if (this.domElement) {
                    this.domElement.style.WebkitUserSelect = "none"
                }
            }
            this.draw()
        },
        initialize: function (T) {
            throw "initialize\u65b9\u6cd5\u672a\u5b9e\u73b0"
        },
        draw: function () {
            throw "draw\u65b9\u6cd5\u672a\u5b9e\u73b0"
        },
        remove: function () {
            if (this.domElement && this.domElement.parentNode) {
                this.domElement.parentNode.removeChild(this.domElement)
            }
            this.domElement = null;
            this.dispatchEvent(new a9("onremove"))
        },
        hide: function () {
            if (this.domElement) {
                a1.dom.hide(this.domElement)
            }
        },
        show: function () {
            if (this.domElement) {
                a1.dom.show(this.domElement)
            }
        },
        isVisible: function () {
            if (!this.domElement) {
                return false
            }
            if (this.domElement.style.display == "none" || this.domElement.style.visibility == "hidden") {
                return false
            }
            return true
        }
    });
    BMap.register(function (cD) {
        var T = cD.temp;
        T.overlayDiv = cD.overlayDiv = cC(cD.platform, 200);
        cD._panes.floatPane = cC(T.overlayDiv, 800);
        cD._panes.markerMouseTarget = cC(T.overlayDiv, 700);
        cD._panes.floatShadow = cC(T.overlayDiv, 600);
        cD._panes.labelPane = cC(T.overlayDiv, 500);
        cD._panes.markerPane = cC(T.overlayDiv, 400);
        cD._panes.markerShadow = cC(T.overlayDiv, 300);
        cD._panes.mapPane = cC(T.overlayDiv, 200);
        function cC(cE, cH) {
            var cG = W("div"),
            cF = cG.style;
            cF.position = "absolute";
            cF.top = cF.left = cF.width = cF.height = "0";
            cF.zIndex = cH;
            cE.appendChild(cG);
            return cG
        }
    });
    function U() {
        a1.lang.Class.call(this);
        bz.call(this);
        this.map = null;
        this._visible = true;
        this.infoWindow = null;
        this._dblclickTime = 0
    }
    a1.lang.inherits(U, bz, "OverlayInternal");
    a1.extend(U.prototype, {
        initialize: function (T) {
            this.map = T;
            a1.lang.Class.call(this, this.guid);
            return null
        },
        getMap: function () {
            return this.map
        },
        draw: function () { },
        remove: function () {
            this.map = null;
            a1.lang.decontrol(this.guid);
            bz.prototype.remove.call(this)
        },
        hide: function () {
            if (this._visible == false) {
                return
            }
            this._visible = false
        },
        show: function () {
            if (this._visible == true) {
                return
            }
            this._visible = true
        },
        isVisible: function () {
            if (!this.domElement) {
                return false
            }
            return !!this._visible
        },
        getContainer: function () {
            return this.domElement
        },
        setConfig: function (cC) {
            cC = cC || {};
            for (var T in cC) {
                this._config[T] = cC[T]
            }
        },
        setZIndex: function (T) {
            this.zIndex = T
        },
        enableMassClear: function () {
            this._config.enableMassClear = true
        },
        disableMassClear: function () {
            this._config.enableMassClear = false
        },
        addContextMenu: function (T) {
            this._menu = T
        },
        removeContextMenu: function (T) {
            this._menu = null
        }
    });
    function cj() {
        this.map = null;
        this._overlays = {};
        this._customOverlays = []
    }
    BMap.register(function (cC) {
        var T = new cj();
        T.map = cC;
        cC._overlays = T._overlays;
        cC._customOverlays = T._customOverlays;
        cC.addEventListener("load",
        function (cD) {
            T.draw(cD)
        });
        cC.addEventListener("moveend",
        function (cD) {
            T.draw(cD)
        });
        if (a1.browser.ie && a1.browser.ie < 8 || document.compatMode == "BackCompat") {
            cC.addEventListener("zoomend",
            function (cD) {
                setTimeout(function () {
                    T.draw(cD)
                },
                20)
            })
        } else {
            cC.addEventListener("zoomend",
            function (cD) {
                T.draw(cD)
            })
        }
        cC.addEventListener("maptypechange",
        function (cD) {
            T.draw(cD)
        });
        cC.addEventListener("addoverlay",
        function (cH) {
            var cE = cH.target;
            if (cE instanceof U) {
                if (!T._overlays[cE.guid]) {
                    T._overlays[cE.guid] = cE
                }
            } else {
                var cG = false;
                for (var cF = 0,
                cD = T._customOverlays.length; cF < cD; cF++) {
                    if (T._customOverlays[cF] === cE) {
                        cG = true;
                        break
                    }
                }
                if (!cG) {
                    T._customOverlays.push(cE)
                }
            }
        });
        cC.addEventListener("removeoverlay",
        function (cG) {
            var cE = cG.target;
            if (cE instanceof U) {
                delete T._overlays[cE.guid]
            } else {
                for (var cF = 0,
                cD = T._customOverlays.length; cF < cD; cF++) {
                    if (T._customOverlays[cF] === cE) {
                        T._customOverlays.splice(cF, 1);
                        break
                    }
                }
            }
        });
        cC.addEventListener("clearoverlays",
        function (cG) {
            this.closeInfoWindow();
            for (var cF in T._overlays) {
                if (T._overlays[cF]._config.enableMassClear) {
                    T._overlays[cF].remove();
                    delete T._overlays[cF]
                }
            }
            for (var cE = 0,
            cD = T._customOverlays.length; cE < cD; cE++) {
                if (T._customOverlays[cE].enableMassClear != false) {
                    T._customOverlays[cE].remove();
                    T._customOverlays[cE] = null;
                    T._customOverlays.splice(cE, 1);
                    cE--;
                    cD--
                }
            }
        });
        cC.addEventListener("infowindowopen",
        function (cE) {
            var cD = this.infoWindow;
            if (cD) {
                a1.dom.hide(cD.popDom);
                a1.dom.hide(cD.shadowDom)
            }
        });
        cC.addEventListener("movestart",
        function () {
            if (this.getInfoWindow()) {
                this.getInfoWindow()._setOverflow()
            }
        });
        cC.addEventListener("moveend",
        function () {
            if (this.getInfoWindow()) {
                this.getInfoWindow()._resetOverflow()
            }
        })
    });
    cj.prototype.draw = function (cD) {
        for (var cC in this._overlays) {
            this._overlays[cC].draw()
        }
        a1.array.each(this._customOverlays,
        function (cE) {
            cE.draw()
        });
        if (this.map.temp.infoWin) {
            this.map.temp.infoWin.setPosition()
        }
        if (BMap.DrawerSelector) {
            var T = BMap.DrawerSelector.getDrawer(this.map);
            T.setPalette()
        }
    };
    function cw(T) {
        U.call(this);
        this._config = {
            strokeColor: "#3a6bdb",
            strokeWeight: 5,
            strokeOpacity: 0.65,
            strokeStyle: "solid",
            enableMassClear: true,
            getParseTolerance: null,
            getParseCacheIndex: null,
            enableEditing: false,
            mouseOverTolerance: 15,
            use3DCoords: false,
            clickable: true
        };
        T = T || {};
        this.setConfig(T);
        if (this._config.strokeWeight <= 0) {
            this._config.strokeWeight = 5
        }
        if (this._config.strokeOpacity < 0 || this._config.strokeOpacity > 1) {
            this._config.strokeOpacity = 0.65
        }
        if (this._config.fillOpacity < 0 || this._config.fillOpacity > 1) {
            this._config.fillOpacity = 0.65
        }
        if (this._config.strokeStyle != "solid" && this._config.strokeStyle != "dashed") {
            this._config.strokeStyle = "solid"
        }
        if (b8(T.enableClicking)) {
            this._config.clickable = T.enableClicking
        }
        this.domElement = null;
        this._bounds = new BMap.Bounds(0, 0, 0, 0);
        this._parseCache = [];
        this.vertexMarkers = [];
        this._temp = {}
    }
    a1.lang.inherits(cw, U, "Graph");
    cw.getGraphPoints = function (cC) {
        var T = [];
        if (!cC) {
            return T
        }
        if (bV(cC)) {
            var cD = cC.split(";");
            a1.array.each(cD,
            function (cF) {
                var cE = cF.split(",");
                T.push(new b4(cE[0], cE[1]))
            })
        }
        if (cC.constructor == Array && cC.length > 0) {
            T = cC
        }
        return T
    };
    cw.parseTolerance = [0.09, 0.005, 0.0001, 0.00001];
    a1.extend(cw.prototype, {
        initialize: function (T) {
            this.map = T;
            return null
        },
        draw: function () {
            return;
            if (!this.domElement) {
                return
            }
            if (this._drawer) {
                this._drawer.setPath(this.domElement, this._getDisplayPixels(this.points))
            }
        },
        setPath: function (T) {
            this._parseCache.length = 0;
            this.points = cw.getGraphPoints(T).slice(0);
            this._calcBounds()
        },
        _calcBounds: function () {
            if (!this.points) {
                return
            }
            var T = this;
            T._bounds = new bF();
            a1.array.each(this.points,
            function (cC) {
                T._bounds.extend(cC)
            })
        },
        getPath: function () {
            return this.points
        },
        setPositionAt: function (cC, T) {
            if (!T || !this.points[cC]) {
                return
            }
            this._parseCache.length = 0;
            this.points[cC] = new b4(T.lng, T.lat);
            this._calcBounds()
        },
        setStrokeColor: function (T) {
            this._config.strokeColor = T
        },
        getStrokeColor: function () {
            return this._config.strokeColor
        },
        setStrokeWeight: function (T) {
            if (T > 0) {
                this._config.strokeWeight = T
            }
        },
        getStrokeWeight: function () {
            return this._config.strokeWeight
        },
        setStrokeOpacity: function (T) {
            if (!T || T > 1 || T < 0) {
                return
            }
            this._config.strokeOpacity = T
        },
        getStrokeOpacity: function () {
            return this._config.strokeOpacity
        },
        setFillOpacity: function (T) {
            if (T > 1 || T < 0) {
                return
            }
            this._config.fillOpacity = T
        },
        getFillOpacity: function () {
            return this._config.fillOpacity
        },
        setStrokeStyle: function (T) {
            if (T != "solid" && T != "dashed") {
                return
            }
            this._config.strokeStyle = T
        },
        getStrokeStyle: function () {
            return this._config.strokeStyle
        },
        setFillColor: function (T) {
            this._config.fillColor = T || ""
        },
        getFillColor: function () {
            return this._config.fillColor
        },
        getBounds: function () {
            return this._bounds
        },
        remove: function () {
            if (this.map) {
                this.map.removeEventListener("onmousemove", this._graphMouseEvent)
            }
            U.prototype.remove.call(this);
            this._parseCache.length = 0
        },
        enableEditing: function () {
            this._config.enableEditing = true
        },
        disableEditing: function () {
            this._config.enableEditing = false
        }
    });
    function l(T) {
        U.call(this);
        this.map = null;
        this.domElement = null;
        this._config = {
            width: 0,
            height: 0,
            offset: new aB(0, 0),
            opacity: 1,
            background: "transparent",
            lineStroke: 1,
            lineColor: "#000",
            lineStyle: "solid",
            point: null
        };
        this.setConfig(T);
        this.point = this._config.point
    }
    a1.lang.inherits(l, U, "Division");
    a1.extend(l.prototype, {
        _addDom: function () {
            var T = this._config;
            var cD = this.content;
            var cC = ['<div class="BMap_Division" style="position:absolute;'];
            cC.push("width:" + T.width + "px;display:block;");
            cC.push("overflow:hidden;");
            if (T.borderColor != "none") {
                cC.push("border:" + T.lineStroke + "px " + T.lineStyle + " " + T.lineColor + ";")
            }
            cC.push("opacity:" + T.opacity + "; filter:(opacity=" + T.opacity * 100 + ")");
            cC.push("background:" + T.background + ";");
            cC.push('z-index:60;">');
            cC.push(cD);
            cC.push("</div>");
            this.domElement = an(this.map.getPanes().markerMouseTarget, cC.join(""))
        },
        initialize: function (T) {
            this.map = T;
            this._addDom();
            if (this.domElement) {
                a1.on(this.domElement, "mousedown",
                function (cC) {
                    aJ(cC)
                })
            }
            return this.domElement
        },
        draw: function () {
            var T = this.map.pointToOverlayPixel(this._config.point);
            this._config.offset = new aB(-Math.round(this._config.width / 2) - Math.round(this._config.lineStroke), -Math.round(this._config.height / 2) - Math.round(this._config.lineStroke));
            this.domElement.style.left = T.x + this._config.offset.width + "px";
            this.domElement.style.top = T.y + this._config.offset.height + "px"
        },
        getPosition: function () {
            return this._config.point
        },
        _getPixel: function (T) {
            return this.map.pointToPixel(this.getPosition())
        },
        setPosition: function (T) {
            this._config.point = T;
            this.draw()
        },
        setDimension: function (T, cC) {
            this._config.width = Math.round(T);
            this._config.height = Math.round(cC);
            if (this.domElement) {
                this.domElement.style.width = this._config.width + "px";
                this.domElement.style.height = this._config.height + "px";
                this.draw()
            }
        }
    });
    function K(cC, cD, cE) {
        if (!cC || !cD) {
            return
        }
        this.imageUrl = cC;
        this.size = cD;
        var T = new aB(Math.floor(cD.width / 2), Math.floor(cD.height / 2));
        var cF = {
            anchor: T,
            imageOffset: new aB(0, 0)
        };
        cE = cE || {};
        a1.extend(cF, cE);
        this.anchor = cF.anchor;
        this.imageOffset = cF.imageOffset;
        this.infoWindowAnchor = cE.infoWindowAnchor || this.anchor;
        this.printImageUrl = cE.printImageUrl || ""
    }
    var bw = K.prototype;
    bw.setImageUrl = function (T) {
        if (!T) {
            return
        }
        this.imageUrl = T
    };
    bw.setPrintImageUrl = function (T) {
        if (!T) {
            return
        }
        this.printImageUrl = T
    };
    bw.setSize = function (T) {
        if (!T) {
            return
        }
        this.size = new aB(T.width, T.height)
    };
    bw.setAnchor = function (T) {
        if (!T) {
            return
        }
        this.anchor = new aB(T.width, T.height)
    };
    bw.setImageOffset = function (T) {
        if (!T) {
            return
        }
        this.imageOffset = new aB(T.width, T.height)
    };
    bw.setInfoWindowAnchor = function (T) {
        if (!T) {
            return
        }
        this.infoWindowAnchor = new aB(T.width, T.height)
    };
    bw.toString = function () {
        return "Icon"
    };
    function bH(cD, cC) {
        a1.lang.Class.call(this);
        this.content = cD;
        this.map = null;
        this._config = {
            width: 0,
            height: 0,
            maxWidth: 600,
            offset: new aB(0, 0),
            title: "",
            maxContent: "",
            enableMaximize: false,
            enableAutoPan: true,
            enableCloseOnClick: true,
            margin: [10, 10, 40, 10],
            collisions: [[10, 10], [10, 10], [10, 10], [10, 10]],
            ifMaxScene: false,
            onClosing: function () {
                return true
            }
        };
        a1.extend(this._config, cC || {});
        if (this._config.width != 0) {
            if (this._config.width < 220) {
                this._config.width = 220
            }
            if (this._config.width > 730) {
                this._config.width = 730
            }
        }
        if (this._config.height != 0) {
            if (this._config.height < 60) {
                this._config.height = 60
            }
            if (this._config.height > 650) {
                this._config.height = 650
            }
        }
        if (this._config.maxWidth != 0) {
            if (this._config.maxWidth < 220) {
                this._config.maxWidth = 220
            }
            if (this._config.maxWidth > 730) {
                this._config.maxWidth = 730
            }
        }
        this.isWinMax = false;
        this.IMG_PATH = b3.imgPath;
        this.overlay = null;
        var T = this;
        cr.load("infowindow",
        function () {
            T._draw()
        })
    }
    a1.lang.inherits(bH, a1.lang.Class, "InfoWindow");
    a1.extend(bH.prototype, {
        setWidth: function (T) {
            if (!T && T != 0 || isNaN(T) || T < 0) {
                return
            }
            if (T != 0) {
                if (T < 220) {
                    T = 220
                }
                if (T > 730) {
                    T = 730
                }
            }
            this._config.width = T
        },
        setHeight: function (T) {
            if (!T && T != 0 || isNaN(T) || T < 0) {
                return
            }
            if (T != 0) {
                if (T < 60) {
                    T = 60
                }
                if (T > 650) {
                    T = 650
                }
            }
            this._config.height = T
        },
        setMaxWidth: function (T) {
            if (!T && T != 0 || isNaN(T) || T < 0) {
                return
            }
            if (T != 0) {
                if (T < 220) {
                    T = 220
                }
                if (T > 730) {
                    T = 730
                }
            }
            this._config.maxWidth = T
        },
        setTitle: function (T) {
            this._config.title = T
        },
        getTitle: function () {
            return this._config.title
        },
        setContent: function (T) {
            this.content = T
        },
        getContent: function () {
            return this.content
        },
        setMaxContent: function (T) {
            this._config.maxContent = T + ""
        },
        redraw: function () { },
        enableAutoPan: function () {
            this._config.enableAutoPan = true
        },
        disableAutoPan: function () {
            this._config.enableAutoPan = false
        },
        enableCloseOnClick: function () {
            this._config.enableCloseOnClick = true
        },
        disableCloseOnClick: function () {
            this._config.enableCloseOnClick = false
        },
        enableMaximize: function () {
            this._config.enableMaximize = true
        },
        disableMaximize: function () {
            this._config.enableMaximize = false
        },
        show: function () {
            this._visible = true
        },
        hide: function () {
            this._visible = false
        },
        close: function () {
            this.hide()
        },
        maximize: function () {
            this.isWinMax = true
        },
        restore: function () {
            this.isWinMax = false
        },
        isVisible: function () {
            return this.isOpen()
        },
        isOpen: function () {
            return false
        },
        getPosition: function () {
            if (this.overlay && this.overlay.getPosition) {
                return this.overlay.getPosition()
            }
        },
        getOffset: function () {
            return this._config.offset
        }
    });
    bs.prototype.openInfoWindow = function (cE, T) {
        if (!(cE instanceof bH) || !(T instanceof b4)) {
            return
        }
        var cC = this.temp;
        if (!cC.marker) {
            var cD = new K(b3.imgPath + "blank.gif", {
                width: 1,
                height: 1
            });
            cC.marker = new Z(T, {
                icon: cD,
                width: 1,
                height: 1,
                offset: new aB(0, 0),
                infoWindowOffset: new aB(0, 0),
                clickable: false
            });
            cC.marker._fromMap = 1
        } else {
            cC.marker.setPosition(T)
        }
        this.addOverlay(cC.marker);
        cC.marker.openInfoWindow(cE)
    };
    bs.prototype.closeInfoWindow = function () {
        var T = this.temp.infoWin || this.temp._infoWin;
        if (T && T.overlay) {
            T.overlay.closeInfoWindow()
        }
    };
    U.prototype.openInfoWindow = function (T) {
        if (this.map) {
            this.map.closeInfoWindow();
            T._visible = true;
            this.map.temp._infoWin = T;
            T.overlay = this;
            a1.lang.Class.call(T, T.guid)
        }
    };
    U.prototype.closeInfoWindow = function () {
        if (this.map && this.map.temp._infoWin) {
            this.map.temp._infoWin._visible = false;
            a1.lang.decontrol(this.map.temp._infoWin.guid);
            this.map.temp._infoWin = null
        }
    };
    function ac(cD, cC) {
        U.call(this);
        this.content = cD;
        this.map = null;
        this.domElement = null;
        this._config = {
            width: 0,
            offset: new aB(0, 0),
            styles: {
                backgroundColor: "#fff",
                border: "1px solid #f00",
                padding: "1px",
                whiteSpace: "nowrap",
                font: "12px " + b3.fontFamily,
                zIndex: "80",
                MozUserSelect: "none"
            },
            position: null,
            enableMassClear: true,
            clickable: true
        };
        cC = cC || {};
        this.setConfig(cC);
        if (this._config.width < 0) {
            this._config.width = 0
        }
        if (b8(cC.enableClicking)) {
            this._config.clickable = cC.enableClicking
        }
        this.point = this._config.position;
        var T = this;
        cr.load("marker",
        function () {
            T._draw()
        })
    }
    a1.lang.inherits(ac, U, "Label");
    a1.extend(ac.prototype, {
        getPosition: function () {
            if (this._marker) {
                return this._marker.getPosition()
            }
            return this.point
        },
        setPosition: function (T) {
            if (T instanceof b4 && !this.getMarker()) {
                this.point = this._config.position = new b4(T.lng, T.lat)
            }
        },
        setContent: function (T) {
            this.content = T
        },
        setOpacity: function (T) {
            if (T >= 0 && T <= 1) {
                this._config.opacity = T
            }
        },
        setOffset: function (T) {
            if (!(T instanceof aB)) {
                return
            }
            this._config.offset = new aB(T.width, T.height)
        },
        getOffset: function () {
            return this._config.offset
        },
        setStyle: function (T) {
            T = T || {};
            this._config.styles = a1.extend(this._config.styles, T)
        },
        setStyles: function (T) {
            return this.setStyle(T)
        },
        setTitle: function (T) {
            this._config.title = T || ""
        },
        getTitle: function () {
            return this._config.title
        },
        setMarker: function (T) {
            this._marker = T;
            if (T) {
                this.point = this._config.position = T.getPosition()
            } else {
                this.point = this._config.position = null
            }
        },
        getMarker: function () {
            return this._marker || null
        }
    });
    window.BMAP_ANIMATION_DROP = 1;
    window.BMAP_ANIMATION_BOUNCE = 2;
    var ao = new K(b3.imgPath + "marker_red_sprite.png", new aB(19, 25), {
        anchor: new aB(10, 25),
        infoWindowAnchor: new aB(10, 0)
    });
    var am = new K(b3.imgPath + "marker_red_sprite.png", new aB(20, 11), {
        anchor: new aB(6, 11),
        imageOffset: new aB(-19, -13)
    });
    function Z(T, cD) {
        U.call(this);
        cD = cD || {};
        this.point = T;
        this.map = null;
        this._animation = null;
        this._config = {
            offset: new aB(0, 0),
            icon: ao,
            shadow: am,
            title: "",
            label: null,
            baseZIndex: 0,
            clickable: true,
            zIndexFixed: false,
            isTop: false,
            enableMassClear: true,
            enableDragging: false,
            raiseOnDrag: false,
            restrictDraggingArea: false,
            draggingCursor: b3.draggingCursor
        };
        this.setConfig(cD);
        if (cD.icon && !cD.shadow) {
            this._config.shadow = null
        }
        if (b8(cD.enableClicking)) {
            this._config.clickable = cD.enableClicking
        }
        var cC = this;
        cr.load("marker",
        function () {
            cC._draw()
        })
    }
    Z.TOP_ZINDEX = bz.getZIndex(-90) + 1000000;
    Z.DRAG_ZINDEX = Z.TOP_ZINDEX + 1000000;
    a1.lang.inherits(Z, U, "Marker");
    a1.extend(Z.prototype, {
        setIcon: function (T) {
            if (T instanceof K) {
                this._config.icon = T
            }
        },
        getIcon: function () {
            return this._config.icon
        },
        setShadow: function (T) {
            if (T instanceof K) {
                this._config.shadow = T
            }
        },
        getShadow: function () {
            return this._config.shadow
        },
        setLabel: function (T) {
            this._config.label = T || null
        },
        getLabel: function () {
            return this._config.label
        },
        enableDragging: function () {
            this._config.enableDragging = true
        },
        disableDragging: function () {
            this._config.enableDragging = false
        },
        getPosition: function () {
            return this.point
        },
        setPosition: function (T) {
            if (T instanceof b4) {
                this.point = new b4(T.lng, T.lat)
            }
        },
        setTop: function (cC, T) {
            this._config.isTop = !!cC;
            if (cC) {
                this._addi = T || 0
            }
        },
        setTitle: function (T) {
            this._config.title = T + ""
        },
        getTitle: function () {
            return this._config.title
        },
        setOffset: function (T) {
            if (T instanceof aB) {
                this._config.offset = T
            }
        },
        getOffset: function () {
            return this._config.offset
        },
        setAnimation: function (T) {
            this._animation = T
        }
    });
    function ce(T, cD) {
        cw.call(this, cD);
        cD = cD || {};
        this._config.fillOpacity = cD.fillOpacity ? cD.fillOpacity : 0.65;
        if (cD.fillColor == "") {
            this._config.fillColor = ""
        } else {
            this._config.fillColor = cD.fillColor ? cD.fillColor : "#fff"
        }
        this.setPath(T);
        var cC = this;
        cr.load("poly",
        function () {
            cC._draw()
        })
    }
    a1.lang.inherits(ce, cw, "Polygon");
    a1.extend(ce.prototype, {
        setPath: function (cC, T) {
            this._userPoints = cw.getGraphPoints(cC).slice(0);
            var cD = cw.getGraphPoints(cC).slice(0);
            if (cD.length > 1 && !cD[0].equals(cD[cD.length - 1])) {
                cD.push(new b4(cD[0].lng, cD[0].lat))
            }
            cw.prototype.setPath.call(this, cD, T)
        },
        setPositionAt: function (cC, T) {
            if (!this._userPoints[cC]) {
                return
            }
            this._userPoints[cC] = new b4(T.lng, T.lat);
            this.points[cC] = new b4(T.lng, T.lat);
            if (cC == 0 && !this.points[0].equals(this.points[this.points.length - 1])) {
                this.points[this.points.length - 1] = new b4(T.lng, T.lat)
            }
            this._calcBounds()
        },
        getPath: function () {
            var T = this._userPoints;
            if (T.length == 0) {
                T = this.points
            }
            return T
        }
    });
    function f(T, cD) {
        cw.call(this, cD);
        this.setPath(T);
        var cC = this;
        cr.load("poly",
        function () {
            cC._draw()
        })
    }
    a1.lang.inherits(f, cw, "Polyline");
    function a(cC, T, cD) {
        this.point = cC;
        this.radius = Math.abs(T);
        ce.call(this, [], cD)
    }
    a.parseTolerance = [0.01, 0.0001, 0.00001, 0.000004];
    a1.lang.inherits(a, ce, "Circle");
    a1.extend(a.prototype, {
        initialize: function (T) {
            this.map = T;
            this.points = this._getPerimeterPoints(this.point, this.radius);
            this._calcBounds();
            return null
        },
        getCenter: function () {
            return this.point
        },
        setCenter: function (T, cC) {
            if (!T) {
                return
            }
            this.point = T
        },
        getRadius: function () {
            return this.radius
        },
        setRadius: function (T) {
            this.radius = Math.abs(T)
        },
        _getPerimeterPoints: function (T, cJ) {
            if (!T || !cJ || !this.map) {
                return []
            }
            var cC = this.map;
            var cG = T.lng,
            cE = T.lat;
            var cQ = [];
            var cL = cJ / 6378800,
            cI = (Math.PI / 180) * cE,
            cO = (Math.PI / 180) * cG;
            for (var cH = 0; cH < 360; cH += 9) {
                var cF = (Math.PI / 180) * cH,
                cM = Math.asin(Math.sin(cI) * Math.cos(cL) + Math.cos(cI) * Math.sin(cL) * Math.cos(cF)),
                cK = Math.atan2(Math.sin(cF) * Math.sin(cL) * Math.cos(cI), Math.cos(cL) - Math.sin(cI) * Math.sin(cM)),
                cN = ((cO - cK + Math.PI) % (2 * Math.PI)) - Math.PI,
                cP = new b4(cN * (180 / Math.PI), cM * (180 / Math.PI));
                cQ.push(cP)
            }
            var cD = cQ[0];
            cQ.push(new b4(cD.lng, cD.lat));
            return cQ
        }
    });
    function bJ(T) {
        this.map = T;
        this.mapTypeLayers = [];
        this.tileLayers = [];
        this.bufferNumber = 300;
        this.realBufferNumber = 0;
        this.mapTiles = {};
        this.bufferTiles = {};
        this.numLoading = 0;
        this._mapTypeLayerContainer = this._createDiv(1);
        this._normalLayerContainer = this._createDiv(2);
        T.platform.appendChild(this._mapTypeLayerContainer);
        T.platform.appendChild(this._normalLayerContainer)
    }
    BMap.register(function (cC) {
        var T = new bJ(cC);
        T.initialize()
    });
    a1.extend(bJ.prototype, {
        initialize: function () {
            var T = this,
            cC = T.map;
            cC.addEventListener("loadcode",
            function () {
                T.loadTiles()
            });
            cC.addEventListener("addtilelayer",
            function (cD) {
                T.addTileLayer(cD)
            });
            cC.addEventListener("removetilelayer",
            function (cD) {
                T.removeTileLayer(cD)
            });
            cC.addEventListener("setmaptype",
            function (cD) {
                T.setMapType(cD)
            });
            cC.addEventListener("zoomstartcode",
            function (cD) {
                T._zoom(cD)
            })
        },
        loadTiles: function () {
            var T = this;
            if (a1.browser.ie) {
                try {
                    document.execCommand("BackgroundImageCache", false, true)
                } catch (cC) { }
            }
            if (!this.loaded) {
                T.initMapTypeTiles()
            }
            T.moveGridTiles();
            if (!this.loaded) {
                this.loaded = true;
                cr.load("tile",
                function () {
                    T._asyncLoadTiles()
                })
            }
        },
        initMapTypeTiles: function () {
            var cC = this.map.getMapType();
            var cD = cC.getTileLayers();
            for (var T = 0; T < cD.length; T++) {
                var cE = new n();
                a1.extend(cE, cD[T]);
                this.mapTypeLayers.push(cE);
                cE.initialize(this.map, this._mapTypeLayerContainer)
            }
        },
        _createDiv: function (cC) {
            var T = W("div");
            T.style.position = "absolute";
            T.style.left = T.style.top = "0";
            T.style.zIndex = cC;
            return T
        },
        showTile: function (cG, cF, cJ) {
            var cM = this;
            cM.centerPos = cF;
            var cI = this.map.getMapType();
            var cD = cM.getTileName(cG, cJ);
            var cQ = cI.getTileSize();
            var cE = (cG[0] * cQ) + cF[0];
            var cP = 0;
            if (cI === BMAP_PERSPECTIVE_MAP && cM.map.getZoom() == 15) {
                cP = 0.5
            }
            var cC = (cP - 1 - cG[1]) * cQ + cF[1];
            var cK = [cE, cC];
            var cL = this.mapTiles[cD];
            if (cL && cL.img) {
                bB(cL.img, cK);
                if (cL.loaded) {
                    this._checkTilesLoaded()
                } else {
                    cL._addLoadCbk(function () {
                        cM._checkTilesLoaded()
                    })
                }
                return
            }
            cL = this.bufferTiles[cD];
            if (cL && cL.img) {
                cJ.tilesDiv.insertBefore(cL.img, cJ.tilesDiv.lastChild);
                this.mapTiles[cD] = cL;
                bB(cL.img, cK);
                if (cL.loaded) {
                    this._checkTilesLoaded()
                } else {
                    cL._addLoadCbk(function () {
                        cM._checkTilesLoaded()
                    })
                }
                return
            }
            var cO = 256 * Math.pow(2, (cI.getMaxZoom() - cG[2]));
            var cN = new b4(cG[0] * cO, cG[1] * cO);
            var cH = new bn(cG[0], cG[1]);
            var T = cJ.getTilesUrl(cH, cG[2]);
            cL = new bM(this, T, cK, cG, cJ);
            cL._addLoadCbk(function () {
                cM._checkTilesLoaded()
            });
            cL._load();
            this.mapTiles[cD] = cL
        },
        _checkTilesLoaded: function () {
            this.numLoading--;
            var T = this;
            if (this.numLoading == 0) {
                if (this._checkLoadedTimer) {
                    clearTimeout(this._checkLoadedTimer);
                    this._checkLoadedTimer = null
                }
                this._checkLoadedTimer = setTimeout(function () {
                    if (T.numLoading == 0) {
                        T.map.dispatchEvent(new a9("ontilesloaded"))
                    }
                    T._checkLoadedTimer = null
                },
                80)
            }
        },
        getTileName: function (T, cC) {
            if (this.map.getMapType() === BMAP_PERSPECTIVE_MAP) {
                return "TILE-" + cC.guid + "-" + this.map.cityCode + "-" + T[0] + "-" + T[1] + "-" + T[2]
            } else {
                return "TILE-" + cC.guid + "-" + T[0] + "-" + T[1] + "-" + T[2]
            }
        },
        hideTile: function (cC) {
            var T = cC.img;
            if (T) {
                H(T);
                if (w(T)) {
                    T.parentNode.removeChild(T)
                }
            }
            delete this.mapTiles[cC.name];
            if (!cC.loaded) {
                H(T);
                T = null;
                cC._callCbks();
                cC.img = null;
                cC.mgr = null
            }
        },
        moveGridTiles: function () {
            var c1 = this.mapTypeLayers;
            var cN = c1.concat(this.tileLayers);
            var cT = cN.length;
            for (var cV = 0; cV < cT; cV++) {
                var cG = cN[cV];
                if (cG.baseLayer) {
                    this.tilesDiv = cG.tilesDiv
                }
                var c7 = this.map;
                var c3 = c7.getMapType();
                var c8 = c3.getProjection();
                var cU = c7.zoomLevel;
                var cX = c7.mercatorCenter;
                this.mapCenterPoint = cX;
                var cL = c3.getZoomUnits(cU);
                var cO = c3.getZoomFactor(cU);
                var cM = Math.ceil(cX.lng / cO);
                var cH = Math.ceil(cX.lat / cO);
                var cS = c3.getTileSize();
                var cF = [cM, cH, (cX.lng - cM * cO) / cO * cS, (cX.lat - cH * cO) / cO * cS];
                var c2 = cF[0] - Math.ceil((c7.width / 2 - cF[2]) / cS);
                var cE = cF[1] - Math.ceil((c7.height / 2 - cF[3]) / cS);
                var cY = cF[0] + Math.ceil((c7.width / 2 + cF[2]) / cS);
                var cQ = 0;
                if (c3 === BMAP_PERSPECTIVE_MAP && c7.getZoom() == 15) {
                    cQ = 1
                }
                var cP = cF[1] + Math.ceil((c7.height / 2 + cF[3]) / cS) + cQ;
                this.areaCenter = new b4(cX.lng, cX.lat);
                var cD = this.mapTiles;
                var cK = -this.areaCenter.lng / cL;
                var cJ = this.areaCenter.lat / cL;
                var c5 = [Math.round(cK), Math.round(cJ)];
                var cC = c7.getZoom();
                for (var c6 in cD) {
                    var c9 = cD[c6];
                    var c4 = c9.info;
                    if (c4[2] != cC || (c4[2] == cC && (c2 > c4[0] || cY <= c4[0] || cE > c4[1] || cP <= c4[1]))) {
                        this.hideTile(c9)
                    }
                }
                var cI = -c7.offsetX + c7.width / 2;
                var cR = -c7.offsetY + c7.height / 2;
                cG.tilesDiv.style.left = Math.round(cK + cI) - c5[0] + "px";
                cG.tilesDiv.style.top = Math.round(cJ + cR) - c5[1] + "px";
                var T = [];
                for (var c0 = c2; c0 < cY; c0++) {
                    for (var cZ = cE; cZ < cP; cZ++) {
                        T.push([c0, cZ])
                    }
                }
                T.sort((function (da) {
                    return function (db, dc) {
                        return ((0.4 * Math.abs(db[0] - da[0]) + 0.6 * Math.abs(db[1] - da[1])) - (0.4 * Math.abs(dc[0] - da[0]) + 0.6 * Math.abs(dc[1] - da[1])))
                    }
                })([cF[0] - 1, cF[1] - 1]));
                this.numLoading += T.length;
                for (var c0 = 0,
                cW = T.length; c0 < cW; c0++) {
                    this.showTile([T[c0][0], T[c0][1], cC], c5, cG)
                }
            }
            return
        },
        addTileLayer: function (cE) {
            var cD = this;
            var T = cE.target;
            for (var cC = 0; cC < cD.tileLayers.length; cC++) {
                if (cD.tileLayers[cC] == T) {
                    return
                }
            }
            T.initialize(this.map, this._normalLayerContainer);
            cD.tileLayers.push(T)
        },
        removeTileLayer: function (cF) {
            var cE = this;
            var cC = cF.target;
            for (var cD = 0,
            T = cE.tileLayers.length; cD < T; cD++) {
                if (cC == cE.tileLayers[cD]) {
                    cE.tileLayers.splice(cD, 1)
                }
            }
            cC.remove()
        },
        setMapType: function () {
            var cD = this;
            var cE = this.mapTypeLayers;
            for (var cC = 0,
            T = cE.length; cC < T; cC++) {
                cE[cC].remove()
            }
            delete this.tilesDiv;
            this.mapTypeLayers = [];
            this.bufferTiles = this.mapTiles = {};
            this.initMapTypeTiles();
            this.moveGridTiles()
        },
        _zoom: function () {
            var T = this;
            if (T.zoomsDiv) {
                a1.dom.hide(T.zoomsDiv)
            }
            setTimeout(function () {
                T.moveGridTiles();
                T.map.dispatchEvent(new a9("onzoomend"))
            },
            10)
        }
    });
    function bM(cI, T, cF, cC, cE) {
        this.mgr = cI;
        this.position = cF;
        this._cbks = [];
        this.name = cI.getTileName(cC, cE);
        this.info = cC;
        this._transparentPng = cE.isTransparentPng();
        var cJ = W("img");
        cn(cJ);
        cJ.galleryImg = false;
        var cH = cJ.style;
        var cD = cI.map.getMapType();
        cH.position = "absolute";
        cH.border = "none";
        cH.width = cD.getTileSize() + "px";
        cH.height = cD.getTileSize() + "px";
        cH.left = cF[0] + "px";
        cH.top = cF[1] + "px";
        this.img = cJ;
        this.src = T;
        if (C) {
            this.img.style.opacity = 0
        }
        var cG = this;
        this.img.onload = function (cP) {
            cG.loaded = true;
            if (!cG.mgr) {
                return
            }
            var cL = cG.mgr;
            var cK = cL.bufferTiles;
            if (!cK[cG.name]) {
                cL.realBufferNumber++;
                cK[cG.name] = cG
            }
            if (cG.img && !w(cG.img)) {
                if (cE.tilesDiv) {
                    cE.tilesDiv.appendChild(cG.img);
                    if (a1.browser.ie <= 6 && a1.browser.ie > 0 && cG._transparentPng) {
                        cG.img.style.cssText += ';filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="' + cG.src + '",sizingMethod=scale);'
                    }
                }
            }
            var cN = cL.realBufferNumber - cL.bufferNumber;
            for (var cO in cK) {
                if (cN <= 0) {
                    break
                }
                if (!cL.mapTiles[cO]) {
                    cK[cO].mgr = null;
                    var cM = cK[cO].img;
                    if (cM && cM.parentNode) {
                        cM.parentNode.removeChild(cM);
                        H(cM)
                    }
                    cM = null;
                    cK[cO].img = null;
                    delete cK[cO];
                    cL.realBufferNumber--;
                    cN--
                }
            }
            if (C) {
                new g({
                    fps: 20,
                    duration: 200,
                    render: function (cQ) {
                        if (cG.img && cG.img.style) {
                            cG.img.style.opacity = cQ * 1
                        }
                    },
                    finish: function () {
                        if (cG.img && cG.img.style) {
                            delete cG.img.style.opacity
                        }
                    }
                })
            }
            cG._callCbks()
        };
        this.img.onerror = function () {
            cG._callCbks();
            if (!cG.mgr) {
                return
            }
            var cK = cG.mgr;
            var cL = cK.map.getMapType();
            if (cL.getErrorImageUrl()) {
                cG.error = true;
                cG.img.src = cL.getErrorImageUrl();
                if (cG.img && !w(cG.img)) {
                    cE.tilesDiv.appendChild(cG.img)
                }
            }
        };
        cJ = null
    }
    bM.prototype._addLoadCbk = function (T) {
        this._cbks.push(T)
    };
    bM.prototype._load = function () {
        if (a1.browser.ie > 0 && a1.browser.ie <= 6 && this._transparentPng) {
            this.img.src = b3.imgPath + "blank.gif"
        } else {
            this.img.src = this.src
        }
    };
    bM.prototype._callCbks = function () {
        var cC = this;
        for (var T = 0; T < cC._cbks.length; T++) {
            cC._cbks[T]()
        }
        cC._cbks.length = 0
    };
    function H(cE) {
        if (!cE) {
            return
        }
        cE.onload = cE.onerror = null;
        var cC = cE.attributes,
        cD, T, cF;
        if (cC) {
            T = cC.length;
            for (cD = 0; cD < T; cD += 1) {
                cF = cC[cD].name;
                if (G(cE[cF])) {
                    cE[cF] = null
                }
            }
        }
        cC = cE.children;
        if (cC) {
            T = cC.length;
            for (cD = 0; cD < T; cD += 1) {
                H(cE.children[cD])
            }
        }
    }
    var C = (!a1.browser.ie || a1.browser.ie > 8);
    function n(T) {
        this.opts = T || {};
        this.copyright = this.opts.copyright || null;
        this.transparentPng = this.opts.transparentPng || false;
        this.baseLayer = this.opts.baseLayer || false;
        this.zIndex = this.opts.zIndex || 0;
        this.guid = n._guid++
    }
    n._guid = 0;
    a1.lang.inherits(n, a1.lang.Class, "TileLayer");
    a1.extend(n.prototype, {
        initialize: function (cD, T) {
            if (this.baseLayer) {
                this.zIndex = -100
            }
            this.map = cD;
            if (!this.tilesDiv) {
                var cE = W("div");
                var cC = cE.style;
                cC.position = "absolute";
                cC.zIndex = this.zIndex;
                cC.left = Math.ceil(-cD.offsetX + cD.width / 2) + "px";
                cC.top = Math.ceil(-cD.offsetY + cD.height / 2) + "px";
                T.appendChild(cE);
                this.tilesDiv = cE
            }
        },
        remove: function () {
            if (this.tilesDiv && this.tilesDiv.parentNode) {
                this.tilesDiv.innerHTML = "";
                this.tilesDiv.parentNode.removeChild(this.tilesDiv)
            }
            delete this.tilesDiv
        },
        isTransparentPng: function () {
            return this.transparentPng
        },
        getTilesUrl: function (cC, cD) {
            var T = "";
            if (this.opts.tileUrlTemplate) {
                T = this.opts.tileUrlTemplate.replace(/\{X\}/, cC.x);
                T = T.replace(/\{Y\}/, cC.y);
                T = T.replace(/\{Z\}/, cD)
            }
            return T
        },
        getCopyright: function () {
            return this.copyright
        },
        getMapType: function () {
            return this.mapType || BMAP_NORMAL_MAP
        }
    });
    function ax(T) {
        n.call(this, T);
        this._opts = {};
        T = T || {};
        this._opts = a1.object.extend(this._opts, T);
        if (this._opts.predictDate) {
            if (this._opts.predictDate.weekday < 1 || this._opts.predictDate.weekday > 7) {
                this._opts.predictDate = 1
            }
            if (this._opts.predictDate.hour < 0 || this._opts.predictDate.hour > 23) {
                this._opts.predictDate.hour = 0
            }
        }
        this._tileUrl = "http://its.map.baidu.com:8002/traffic/"
    }
    ax.prototype = new n();
    ax.prototype.initialize = function (cC, T) {
        n.prototype.initialize.call(this, cC, T);
        this._map = cC
    };
    ax.prototype.isTransparentPng = function () {
        return true
    };
    ax.prototype.getTilesUrl = function (cH, cC) {
        var cI = "";
        if (this._opts.predictDate) {
            cI = "HistoryService?day=" + (this._opts.predictDate.weekday - 1) + "&hour=" + this._opts.predictDate.hour + "&t=" + new Date().getTime() + "&"
        } else {
            cI = "TrafficTileService?time=" + new Date().getTime() + "&"
        }
        var cD = this._map,
        cJ = cH.x,
        cE = cH.y,
        cG = Math.floor(cJ / 200),
        cF = Math.floor(cE / 200),
        T = this._tileUrl + cI + "level=" + cC + "&x=" + cJ + "&y=" + cE;
        return T.replace(/-(\d+)/gi, "M$1")
    };
    function cl(T, cC, cD) {
        this._name = T;
        this._layers = cC instanceof n ? [cC] : cC.slice(0);
        this._opts = {
            tips: "",
            labelText: "",
            minZoom: 1,
            maxZoom: 19,
            tileSize: 256,
            textColor: "black",
            errorImageUrl: "",
            projection: new a3()
        };
        if (this._layers.length == 1) {
            this._layers[0].baseLayer = true
        }
        a1.extend(this._opts, cD || {})
    }
    a1.extend(cl.prototype, {
        getName: function () {
            return this._name
        },
        getTips: function () {
            return this._opts.tips
        },
        getLabelText: function () {
            return this._opts.labelText
        },
        getTileLayer: function () {
            return this._layers[0]
        },
        getTileLayers: function () {
            return this._layers
        },
        getTileSize: function () {
            return this._opts.tileSize
        },
        getMinZoom: function () {
            return this._opts.minZoom
        },
        getMaxZoom: function () {
            return this._opts.maxZoom
        },
        getTextColor: function () {
            return this._opts.textColor
        },
        getProjection: function () {
            return this._opts.projection
        },
        getErrorImageUrl: function () {
            return this._opts.errorImageUrl
        },
        getZoomUnits: function (T) {
            return Math.pow(2, (18 - T))
        },
        getZoomFactor: function (T) {
            return this.getZoomUnits(T) * 256
        }
    });
    var bY = ["http://shangetu0.map.bdimg.com/it/", "http://shangetu1.map.bdimg.com/it/", "http://shangetu2.map.bdimg.com/it/", "http://shangetu3.map.bdimg.com/it/", "http://shangetu4.map.bdimg.com/it/"];
    var i = ["http://online0.map.bdimg.com/tile/", "http://online1.map.bdimg.com/tile/", "http://online2.map.bdimg.com/tile/", "http://online3.map.bdimg.com/tile/", "http://online4.map.bdimg.com/tile/"];
    var aN = new n();
    aN.getTilesUrl = function (cD, cG) {
        var cH = cD.x;
        var cE = cD.y;
        var T = "20150518";
        var cF = "pl";
        if (this.map.highResolutionEnabled()) {
            cF = "ph"
        }
        var cC = i[Math.abs(cH + cE) % i.length] + "?qt=tile&x=" + (cH + "").replace(/-/gi, "M") + "&y=" + (cE + "").replace(/-/gi, "M") + "&z=" + cG + "&styles=" + cF + (a1.browser.ie == 6 ? "&color_dep=32&colors=50" : "") + "&udt=" + T;
        return cC.replace(/-(\d+)/gi, "M$1")
    };
    window.BMAP_NORMAL_MAP = new cl("\u5730\u56fe", aN, {
        tips: "\u663e\u793a\u666e\u901a\u5730\u56fe"
    });
    var bl = new n();
    bl.tileUrls = ["http://d0.map.baidu.com/resource/mappic/", "http://d1.map.baidu.com/resource/mappic/", "http://d2.map.baidu.com/resource/mappic/", "http://d3.map.baidu.com/resource/mappic/"];
    bl.getTilesUrl = function (T, cD) {
        var cF = T.x;
        var cC = T.y;
        var cE = Math.pow(2, (20 - cD)) * 256;
        cC = Math.round((9998336 - cE * (cC)) / cE) - 1;
        url = this.tileUrls[Math.abs(cF + cC) % this.tileUrls.length] + this.map.currentCity + "/" + this.map.cityCode + "/3/lv" + (21 - cD) + "/" + cF + "," + cC + ".jpg";
        return url
    };
    window.BMAP_PERSPECTIVE_MAP = new cl("\u4e09\u7ef4", bl, {
        tips: "\u663e\u793a\u4e09\u7ef4\u5730\u56fe",
        minZoom: 15,
        maxZoom: 20,
        textColor: "white",
        projection: new cv()
    });
    BMAP_PERSPECTIVE_MAP.getZoomUnits = function (T) {
        return Math.pow(2, (20 - T))
    };
    BMAP_PERSPECTIVE_MAP.getCityName = function (T) {
        if (!T) {
            return ""
        }
        var cC = b3.cityNames;
        for (var cD in cC) {
            if (T.search(cD) > -1) {
                return cC[cD]
            }
        }
        return ""
    };
    BMAP_PERSPECTIVE_MAP.getCityCode = function (T) {
        return ({
            bj: 2,
            gz: 1,
            sz: 14,
            sh: 4
        })[T]
    };
    var bI = new n({
        baseLayer: true
    });
    bI.getTilesUrl = function (cC, cE) {
        var cF = cC.x;
        var cD = cC.y;
        var T = bY[Math.abs(cF + cD) % bY.length] + "u=x=" + cF + ";y=" + cD + ";z=" + cE + ";v=009;type=sate&fm=46&udt=20141015";
        return T.replace(/-(\d+)/gi, "M$1")
    };
    window.BMAP_SATELLITE_MAP = new cl("\u536b\u661f", bI, {
        tips: "\u663e\u793a\u536b\u661f\u5f71\u50cf",
        minZoom: 1,
        maxZoom: 19,
        textColor: "white"
    });
    var m = new n({
        transparentPng: true
    });
    m.getTilesUrl = function (cE, cG) {
        var cH = cE.x;
        var cF = cE.y;
        var T = "20141015";
        var cC = "015";
        var cD = i[Math.abs(cH + cF) % i.length] + "?qt=tile&x=" + (cH + "").replace(/-/gi, "M") + "&y=" + (cF + "").replace(/-/gi, "M") + "&z=" + cG + "&styles=sl" + (a1.browser.ie == 6 ? "&color_dep=32&colors=50" : "") + "&v=" + cC + "&udt=" + T;
        return cD.replace(/-(\d+)/gi, "M$1")
    };
    window.BMAP_HYBRID_MAP = new cl("\u6df7\u5408", [bI, m], {
        tips: "\u663e\u793a\u5e26\u6709\u8857\u9053\u7684\u536b\u661f\u5f71\u50cf",
        labelText: "\u8def\u7f51",
        minZoom: 1,
        maxZoom: 19,
        textColor: "white"
    });
    window.BMAP_POI_TYPE_NORMAL = 0;
    window.BMAP_POI_TYPE_BUSSTOP = 1;
    window.BMAP_POI_TYPE_BUSLINE = 2;
    window.BMAP_POI_TYPE_SUBSTOP = 3;
    window.BMAP_POI_TYPE_SUBLINE = 4;
    var F = 0;
    var ba = 1;
    var aj = {};
    function u(cC, T) {
        a1.lang.Class.call(this);
        this._loc = {};
        this.setLocation(cC);
        this._opts = {
            renderOptions: {
                panel: null,
                map: null,
                autoViewport: true
            },
            onSearchComplete: function () { },
            onMarkersSet: function () { },
            onInfoHtmlSet: function () { },
            onResultsHtmlSet: function () { },
            onGetBusListComplete: function () { },
            onGetBusLineComplete: function () { },
            onBusListHtmlSet: function () { },
            onBusLineHtmlSet: function () { },
            onPolylinesSet: function () { },
            reqFrom: ""
        };
        a1.extend(this._opts, T);
        if (typeof T != "undefined" && typeof T.renderOptions != "undefined" && typeof T.renderOptions.autoViewport != "undefined") {
            this._opts.renderOptions.autoViewport = T.renderOptions.autoViewport
        } else {
            this._opts.renderOptions.autoViewport = true
        }
        this._opts.renderOptions.panel = a1.G(this._opts.renderOptions.panel)
    }
    a1.inherits(u, a1.lang.Class);
    a1.extend(u.prototype, {
        getResults: function () {
            if (!this._isMultiKey) {
                return this._results
            } else {
                return this._arrResults
            }
        },
        enableAutoViewport: function () {
            this._opts.renderOptions.autoViewport = true
        },
        disableAutoViewport: function () {
            this._opts.renderOptions.autoViewport = false
        },
        setLocation: function (T) {
            if (!T) {
                return
            }
            this._loc.src = T
        },
        setSearchCompleteCallback: function (T) {
            this._opts.onSearchComplete = T ||
            function () { }
        },
        setMarkersSetCallback: function (T) {
            this._opts.onMarkersSet = T ||
            function () { }
        },
        setPolylinesSetCallback: function (T) {
            this._opts.onPolylinesSet = T ||
            function () { }
        },
        setInfoHtmlSetCallback: function (T) {
            this._opts.onInfoHtmlSet = T ||
            function () { }
        },
        setResultsHtmlSetCallback: function (T) {
            this._opts.onResultsHtmlSet = T ||
            function () { }
        },
        getStatus: function () {
            return this._status
        }
    });
    var a4 = {
        REQ_BASE_URL: "http://api.map.baidu.com/",
        request: function (cC, cI, T, cH) {
            var cD = (Math.random() * 100000).toFixed(0);
            BMap._rd["_cbk" + cD] = function (cJ) {
                T = T || {};
                cC && cC(cJ, T);
                delete BMap._rd["_cbk" + cD]
            };
            cH = cH || "";
            var cF;
            if (T && T.useEncodeURI) {
                cF = M(cI, encodeURI)
            } else {
                cF = M(cI, encodeURIComponent)
            }
            var cG = this,
            cE = cG.REQ_BASE_URL + cH + "?" + cF + "&ie=utf-8&oue=1&res=api&callback=BMap._rd._cbk" + cD;
            co.request(cE)
        }
    };
    BMap._rd = {};
    var P = {};
    P.removeHtml = function (T) {
        return T.replace(/<\/?b>/g, "")
    };
    P.parseGeoExtReg1 = function (T) {
        return T.replace(/([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0|[1-9]\d*),([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0|[1-9]\d*)(,)/g, "$1,$2;")
    };
    P.parseGeoExtReg2 = function (cC, T) {
        var cD = new RegExp("(((-?\\d+)(\\.\\d+)?),((-?\\d+)(\\.\\d+)?);)(((-?\\d+)(\\.\\d+)?),((-?\\d+)(\\.\\d+)?);){" + T + "}", "ig");
        return cC.replace(cD, "$1")
    };
    window.BMAP_STATUS_SUCCESS = 0;
    window.BMAP_STATUS_CITY_LIST = 1;
    window.BMAP_STATUS_UNKNOWN_LOCATION = 2;
    window.BMAP_STATUS_UNKNOWN_ROUTE = 3;
    window.BMAP_STATUS_INVALID_KEY = 4;
    window.BMAP_STATUS_INVALID_REQUEST = 5;
    window.BMAP_STATUS_PERMISSION_DENIED = 6;
    window.BMAP_STATUS_SERVICE_UNAVAILABLE = 7;
    window.BMAP_STATUS_TIMEOUT = 8;
    window.BMAP_ROUTE_TYPE_WALKING = 2;
    window.BMAP_ROUTE_TYPE_DRIVING = 3;
    var cm = "cur";
    var c = "cen";
    var ca = "s";
    var N = "con";
    var ah = "bd";
    var b2 = "nb";
    var D = "bt";
    var bE = "nav";
    var bo = "walk";
    var bt = "gc";
    var d = "rgc";
    var Q = "dec";
    var aK = "bse";
    var e = "nse";
    var E = "bl";
    var a8 = "bsl";
    var aA = "bda";
    var ae = "sa";
    var aU = "nba";
    var b9 = "drag";
    var p = 2;
    var aY = 4;
    var bm = 7;
    var S = 11;
    var aH = 12;
    var bb = 14;
    var aV = 15;
    var cp = 18;
    var s = 20;
    var O = 21;
    var al = 26;
    var bx = 28;
    var x = 31;
    var bj = 35;
    var bv = 44;
    var ar = 45;
    var aa = 46;
    var bK = 47;
    var aT = -1;
    var X = 0;
    var ch = 1;
    var aZ = 2;
    var z = 3;
    var cz = "http://map.baidu.com/";
    var v = "http://api.map.baidu.com/";
    BMap.I = window.Instance = a1.lang.instance;
    var aX = function (cD, cC) {
        u.call(this, cD, cC);
        cC = cC || {};
        cC.renderOptions = cC.renderOptions || {};
        this.setPageCapacity(cC.pageCapacity);
        if (typeof cC.renderOptions.selectFirstResult != "undefined" && !cC.renderOptions.selectFirstResult) {
            this.disableFirstResultSelection()
        } else {
            this.enableFirstResultSelection()
        }
        this._overlays = [];
        this._arrPois = [];
        this._curIndex = -1;
        this._queryList = [];
        var T = this;
        cr.load("local",
        function () {
            T._check()
        })
    };
    a1.inherits(aX, u, "LocalSearch");
    aX.DEFAULT_PAGE_CAPACITY = 10;
    aX.MIN_PAGE_CAPACITY = 1;
    aX.MAX_PAGE_CAPACITY = 100;
    aX.DEFAULT_RADIUS = 2000;
    aX.MAX_RADIUS = 100000;
    a1.extend(aX.prototype, {
        search: function (T) {
            this._queryList.push({
                method: "search",
                arguments: [T]
            })
        },
        searchInBounds: function (T, cC) {
            this._queryList.push({
                method: "searchInBounds",
                arguments: [T, cC]
            })
        },
        searchNearby: function (cD, cC, T) {
            this._queryList.push({
                method: "searchNearby",
                arguments: [cD, cC, T]
            })
        },
        clearResults: function () {
            delete this._json;
            delete this._status;
            delete this._results;
            delete this._ud;
            this._curIndex = -1;
            this._setStatus();
            if (this._opts.renderOptions.panel) {
                this._opts.renderOptions.panel.innerHTML = ""
            }
        },
        gotoPage: function () { },
        enableFirstResultSelection: function () {
            this._opts.renderOptions.selectFirstResult = true
        },
        disableFirstResultSelection: function () {
            this._opts.renderOptions.selectFirstResult = false
        },
        setPageCapacity: function (T) {
            if (typeof T == "number" && !isNaN(T)) {
                this._opts.pageCapacity = T < 1 ? aX.DEFAULT_PAGE_CAPACITY : (T > aX.MAX_PAGE_CAPACITY ? aX.DEFAULT_PAGE_CAPACITY : T)
            } else {
                this._opts.pageCapacity = aX.DEFAULT_PAGE_CAPACITY
            }
        },
        getPageCapacity: function () {
            return this._opts.pageCapacity
        },
        toString: function () {
            return "LocalSearch"
        }
    });
    var bW = function (cC, T) {
        u.call(this, cC, T)
    };
    a1.inherits(bW, u, "BaseRoute");
    a1.extend(bW.prototype, {
        clearResults: function () { }
    });
    window.BMAP_TRANSIT_POLICY_LEAST_TIME = 0;
    window.BMAP_TRANSIT_POLICY_LEAST_TRANSFER = 2;
    window.BMAP_TRANSIT_POLICY_LEAST_WALKING = 3;
    window.BMAP_TRANSIT_POLICY_AVOID_SUBWAYS = 4;
    window.BMAP_LINE_TYPE_BUS = 0;
    window.BMAP_LINE_TYPE_SUBWAY = 1;
    window.BMAP_LINE_TYPE_FERRY = 2;
    function aO(cD, cC) {
        bW.call(this, cD, cC);
        cC = cC || {};
        this.setPolicy(cC.policy);
        this.setPageCapacity(cC.pageCapacity);
        this.QUERY_TYPE = D;
        this.RETURN_TYPE = bb;
        this.ROUTE_TYPE = ba;
        this._overlays = [];
        this._curIndex = -1;
        this._queryList = [];
        var T = this;
        cr.load("route",
        function () {
            T._asyncSearch()
        })
    }
    aO.MAX_PAGE_CAPACITY = 100;
    aO.LINE_TYPE_MAPPING = [0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 1, 1];
    a1.inherits(aO, bW, "TransitRoute");
    a1.extend(aO.prototype, {
        setPolicy: function (T) {
            if (T >= BMAP_TRANSIT_POLICY_LEAST_TIME && T <= BMAP_TRANSIT_POLICY_AVOID_SUBWAYS) {
                this._opts.policy = T
            } else {
                this._opts.policy = BMAP_TRANSIT_POLICY_LEAST_TIME
            }
        },
        _internalSearch: function (cC, T) {
            this._queryList.push({
                method: "_internalSearch",
                arguments: [cC, T]
            })
        },
        search: function (cC, T) {
            this._queryList.push({
                method: "search",
                arguments: [cC, T]
            })
        },
        setPageCapacity: function (T) {
            if (typeof T == "string") {
                T = parseInt(T);
                if (isNaN(T)) {
                    this._opts.pageCapacity = aO.MAX_PAGE_CAPACITY;
                    return
                }
            }
            if (typeof T != "number") {
                this._opts.pageCapacity = aO.MAX_PAGE_CAPACITY;
                return
            }
            if (T >= 1 && T <= aO.MAX_PAGE_CAPACITY) {
                this._opts.pageCapacity = Math.round(T)
            } else {
                this._opts.pageCapacity = aO.MAX_PAGE_CAPACITY
            }
        },
        toString: function () {
            return "TransitRoute"
        },
        _shortTitle: function (T) {
            return T.replace(/\(.*\)/, "")
        }
    });
    window.BMAP_HIGHLIGHT_STEP = 1;
    window.BMAP_HIGHLIGHT_ROUTE = 2;
    var be = function (T, cE) {
        bW.call(this, T, cE);
        this._overlays = [];
        this._curIndex = -1;
        this._queryList = [];
        var cD = this;
        var cC = this._opts.renderOptions;
        if (cC.highlightMode != BMAP_HIGHLIGHT_STEP && cC.highlightMode != BMAP_HIGHLIGHT_ROUTE) {
            cC.highlightMode = BMAP_HIGHLIGHT_STEP
        }
        this._enableDragging = this._opts.renderOptions.enableDragging ? true : false;
        cr.load("route",
        function () {
            cD._asyncSearch()
        })
    };
    be.ROAD_TYPE = ["", "\u73af\u5c9b", "\u65e0\u5c5e\u6027\u9053\u8def", "\u4e3b\u8def", "\u9ad8\u901f\u8fde\u63a5\u8def", "\u4ea4\u53c9\u70b9\u5185\u8def\u6bb5", "\u8fde\u63a5\u9053\u8def", "\u505c\u8f66\u573a\u5185\u90e8\u9053\u8def", "\u670d\u52a1\u533a\u5185\u90e8\u9053\u8def", "\u6865", "\u6b65\u884c\u8857", "\u8f85\u8def", "\u531d\u9053", "\u5168\u5c01\u95ed\u9053\u8def", "\u672a\u5b9a\u4e49\u4ea4\u901a\u533a\u57df", "POI\u8fde\u63a5\u8def", "\u96a7\u9053", "\u6b65\u884c\u9053", "\u516c\u4ea4\u4e13\u7528\u9053", "\u63d0\u524d\u53f3\u8f6c\u9053"];
    a1.inherits(be, bW, "DWRoute");
    a1.extend(be.prototype, {
        search: function (cC, T) {
            this._queryList.push({
                method: "search",
                arguments: [cC, T]
            })
        }
    });
    window.BMAP_DRIVING_POLICY_LEAST_TIME = 0;
    window.BMAP_DRIVING_POLICY_LEAST_DISTANCE = 1;
    window.BMAP_DRIVING_POLICY_AVOID_HIGHWAYS = 2;
    function o(T, cC) {
        be.call(this, T, cC);
        cC = cC || {};
        this.setPolicy(cC.policy);
        this.QUERY_TYPE = bE;
        this.RETURN_TYPE = s;
        this.ROUTE_TYPE = BMAP_ROUTE_TYPE_DRIVING
    }
    a1.inherits(o, be, "DrivingRoute");
    a1.extend(o.prototype, {
        setPolicy: function (T) {
            if (T >= BMAP_DRIVING_POLICY_LEAST_TIME && T <= BMAP_DRIVING_POLICY_AVOID_HIGHWAYS) {
                this._opts.policy = T
            } else {
                this._opts.policy = BMAP_DRIVING_POLICY_LEAST_TIME
            }
        }
    });
    function cu(T, cC) {
        be.call(this, T, cC);
        this.QUERY_TYPE = bo;
        this.RETURN_TYPE = x;
        this.ROUTE_TYPE = BMAP_ROUTE_TYPE_WALKING;
        this._enableDragging = false
    }
    a1.inherits(cu, be, "WalkingRoute");
    function aR(cC) {
        this._opts = {};
        a1.extend(this._opts, cC);
        this._queryList = [];
        var T = this;
        cr.load("othersearch",
        function () {
            T._asyncSearch()
        })
    }
    a1.inherits(aR, a1.lang.Class, "Geocoder");
    a1.extend(aR.prototype, {
        getPoint: function (T, cD, cC) {
            this._queryList.push({
                method: "getPoint",
                arguments: [T, cD, cC]
            })
        },
        getLocation: function (T, cD, cC) {
            this._queryList.push({
                method: "getLocation",
                arguments: [T, cD, cC]
            })
        },
        toString: function () {
            return "Geocoder"
        }
    });
    function ag(cC) {
        this._opts = {};
        a1.extend(this._opts, cC);
        this._queryList = [];
        var T = this;
        cr.load("othersearch",
        function () {
            T._asyncSearch()
        })
    }
    a1.extend(ag.prototype, {
        getCurrentPosition: function (cC, T) {
            this._queryList.push({
                method: "getCurrentPosition",
                arguments: [cC, T]
            })
        },
        getStatus: function () {
            return this._status
        }
    });
    function b0(cC) {
        this._opts = {
            renderOptions: {
                map: null
            }
        };
        a1.extend(this._opts, cC);
        this._queryList = [];
        var T = this;
        cr.load("othersearch",
        function () {
            T._asyncSearch()
        })
    }
    a1.inherits(b0, a1.lang.Class, "LocalCity");
    a1.extend(b0.prototype, {
        get: function (T) {
            this._queryList.push({
                method: "get",
                arguments: [T]
            })
        },
        toString: function () {
            return "LocalCity"
        }
    });
    function bf(cD, cC) {
        u.call(this, cD, cC);
        this.QUERY_TYPE_BUSLIST = E;
        this.RETURN_TYPE_BUSLIST = aV;
        this.QUERY_TYPE_BUSLINE = a8;
        this.RETURN_TYPE_BUSLINE = cp;
        this._queryList = [];
        var T = this;
        cr.load("buslinesearch",
        function () {
            T._asyncSearch()
        })
    }
    bf._iconOpen = b3.imgPath + "iw_plus.gif";
    bf._iconClose = b3.imgPath + "iw_minus.gif";
    bf._stopUrl = b3.imgPath + "stop_icon.png";
    a1.inherits(bf, u);
    a1.extend(bf.prototype, {
        getBusList: function (T) {
            this._queryList.push({
                method: "getBusList",
                arguments: [T]
            })
        },
        getBusLine: function (T) {
            this._queryList.push({
                method: "getBusLine",
                arguments: [T]
            })
        },
        setGetBusListCompleteCallback: function (T) {
            this._opts.onGetBusListComplete = T ||
            function () { }
        },
        setGetBusLineCompleteCallback: function (T) {
            this._opts.onGetBusLineComplete = T ||
            function () { }
        },
        setBusListHtmlSetCallback: function (T) {
            this._opts.onBusListHtmlSet = T ||
            function () { }
        },
        setBusLineHtmlSetCallback: function (T) {
            this._opts.onBusLineHtmlSet = T ||
            function () { }
        },
        setPolylinesSetCallback: function (T) {
            this._opts.onPolylinesSet = T ||
            function () { }
        }
    });
    function br(cC) {
        u.call(this, cC);
        cC = cC || {};
        this._options = {
            input: null,
            types: [],
            onSearchComplete: function () { }
        };
        a1.extend(this._options, cC);
        this._loc.src = cC.location || "\u5168\u56fd";
        this._word = "";
        this._show = false;
        this._suggestion = null;
        _addStat(5011);
        var T = this;
        cr.load("autocomplete",
        function () {
            T._asyncSearch()
        })
    }
    a1.inherits(br, u, "Autocomplete");
    a1.extend(br.prototype, {
        show: function () {
            this._show = true
        },
        hide: function () {
            this._show = false
        },
        setTypes: function (T) {
            this._options.types = T
        },
        setLocation: function (T) {
            this._loc.src = T
        },
        search: function (T) {
            this._word = T
        }
    });
    function af(T, cC) {
        window.BMap[T] = cC
    }
    af("Map", bs);
    af("Hotspot", cd);
    af("MapType", cl);
    af("Point", b4);
    af("Pixel", bn);
    af("Size", aB);
    af("Bounds", bF);
    af("TileLayer", n);
    af("Projection", a6);
    af("MercatorProjection", a3);
    af("PerspectiveProjection", cv);
    af("Copyright", ap);
    af("Overlay", bz);
    af("Label", ac);
    af("Marker", Z);
    af("Icon", K);
    af("Polyline", f);
    af("Polygon", ce);
    af("InfoWindow", bH);
    af("Circle", a);
    af("Control", cg);
    af("NavigationControl", J);
    af("OverviewMapControl", cB);
    af("CopyrightControl", ai);
    af("ScaleControl", bC);
    af("MapTypeControl", aF);
    af("TrafficLayer", ax);
    af("ContextMenu", cq);
    af("MenuItem", a7);
    af("LocalSearch", aX);
    af("TransitRoute", aO);
    af("DrivingRoute", o);
    af("WalkingRoute", cu);
    af("Autocomplete", br);
    af("Geocoder", aR);
    af("LocalCity", b0);
    af("Geolocation", ag);
    af("BusLineSearch", bf);
    window.BMap.apiLoad();
})();