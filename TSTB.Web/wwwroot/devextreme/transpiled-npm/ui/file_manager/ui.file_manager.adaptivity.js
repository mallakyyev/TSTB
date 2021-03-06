"use strict";

exports.default = void 0;

var _renderer = _interopRequireDefault(require("../../core/renderer"));

var _extend = require("../../core/utils/extend");

var _type = require("../../core/utils/type");

var _window = require("../../core/utils/window");

var _ui = _interopRequireDefault(require("../widget/ui.widget"));

var _ui2 = _interopRequireDefault(require("../drawer/ui.drawer"));

var _splitter = _interopRequireDefault(require("../splitter"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _typeof(obj) { "@babel/helpers - typeof"; if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; }; } return _typeof(obj); }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

function _get(target, property, receiver) { if (typeof Reflect !== "undefined" && Reflect.get) { _get = Reflect.get; } else { _get = function _get(target, property, receiver) { var base = _superPropBase(target, property); if (!base) return; var desc = Object.getOwnPropertyDescriptor(base, property); if (desc.get) { return desc.get.call(receiver); } return desc.value; }; } return _get(target, property, receiver || target); }

function _superPropBase(object, property) { while (!Object.prototype.hasOwnProperty.call(object, property)) { object = _getPrototypeOf(object); if (object === null) break; } return object; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function"); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, writable: true, configurable: true } }); if (superClass) _setPrototypeOf(subClass, superClass); }

function _setPrototypeOf(o, p) { _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) { o.__proto__ = p; return o; }; return _setPrototypeOf(o, p); }

function _createSuper(Derived) { var hasNativeReflectConstruct = _isNativeReflectConstruct(); return function _createSuperInternal() { var Super = _getPrototypeOf(Derived), result; if (hasNativeReflectConstruct) { var NewTarget = _getPrototypeOf(this).constructor; result = Reflect.construct(Super, arguments, NewTarget); } else { result = Super.apply(this, arguments); } return _possibleConstructorReturn(this, result); }; }

function _possibleConstructorReturn(self, call) { if (call && (_typeof(call) === "object" || typeof call === "function")) { return call; } return _assertThisInitialized(self); }

function _assertThisInitialized(self) { if (self === void 0) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return self; }

function _isNativeReflectConstruct() { if (typeof Reflect === "undefined" || !Reflect.construct) return false; if (Reflect.construct.sham) return false; if (typeof Proxy === "function") return true; try { Date.prototype.toString.call(Reflect.construct(Date, [], function () {})); return true; } catch (e) { return false; } }

function _getPrototypeOf(o) { _getPrototypeOf = Object.setPrototypeOf ? Object.getPrototypeOf : function _getPrototypeOf(o) { return o.__proto__ || Object.getPrototypeOf(o); }; return _getPrototypeOf(o); }

var window = (0, _window.getWindow)();
var ADAPTIVE_STATE_SCREEN_WIDTH = 573;
var FILE_MANAGER_ADAPTIVITY_DRAWER_PANEL_CLASS = 'dx-filemanager-adaptivity-drawer-panel';
var DRAWER_PANEL_CONTENT_INITIAL = 'dx-drawer-panel-content-initial';

var FileManagerAdaptivityControl = /*#__PURE__*/function (_Widget) {
  _inherits(FileManagerAdaptivityControl, _Widget);

  var _super = _createSuper(FileManagerAdaptivityControl);

  function FileManagerAdaptivityControl() {
    _classCallCheck(this, FileManagerAdaptivityControl);

    return _super.apply(this, arguments);
  }

  _createClass(FileManagerAdaptivityControl, [{
    key: "_initMarkup",
    value: function _initMarkup() {
      _get(_getPrototypeOf(FileManagerAdaptivityControl.prototype), "_initMarkup", this).call(this);

      this._initActions();

      this._isInAdaptiveState = false;
      var $drawer = (0, _renderer.default)('<div>').appendTo(this.$element());
      (0, _renderer.default)('<div>').addClass(FILE_MANAGER_ADAPTIVITY_DRAWER_PANEL_CLASS).appendTo($drawer);
      this._drawer = this._createComponent($drawer, _ui2.default);

      this._drawer.option({
        opened: true,
        template: this._createDrawerTemplate.bind(this)
      });

      (0, _renderer.default)(this._drawer.content()).addClass(DRAWER_PANEL_CONTENT_INITIAL);
      var $drawerContent = $drawer.find(".".concat(FILE_MANAGER_ADAPTIVITY_DRAWER_PANEL_CLASS)).first();
      var contentRenderer = this.option('contentTemplate');

      if ((0, _type.isFunction)(contentRenderer)) {
        contentRenderer($drawerContent);
      }
    }
  }, {
    key: "_createDrawerTemplate",
    value: function _createDrawerTemplate(container) {
      this.option('drawerTemplate')(container);
      this._splitter = this._createComponent('<div>', _splitter.default, {
        container: this.$element(),
        leftElement: (0, _renderer.default)(this._drawer.content()),
        rightElement: (0, _renderer.default)(this._drawer.viewContent()),
        onApplyPanelSize: this._onApplyPanelSize.bind(this)
      });

      this._splitter.$element().appendTo(container);
    }
  }, {
    key: "_render",
    value: function _render() {
      _get(_getPrototypeOf(FileManagerAdaptivityControl.prototype), "_render", this).call(this);

      this._checkAdaptiveState();
    }
  }, {
    key: "_onApplyPanelSize",
    value: function _onApplyPanelSize(e) {
      if (!(0, _window.hasWindow)()) {
        return;
      }

      if (!this._splitter.isSplitterMoved()) {
        this._updateDrawerDimensions();

        return;
      }

      (0, _renderer.default)(this._drawer.content()).removeClass(DRAWER_PANEL_CONTENT_INITIAL);
      (0, _renderer.default)(this._drawer.content()).css('width', e.leftPanelWidth);

      this._drawer._initSize();

      this._drawer.resizeContent();
    }
  }, {
    key: "_updateDrawerDimensions",
    value: function _updateDrawerDimensions() {
      (0, _renderer.default)(this._drawer.content()).css('width', '');

      this._drawer._initSize();

      this._drawer._strategy.setPanelSize(true);
    }
  }, {
    key: "_dimensionChanged",
    value: function _dimensionChanged(dimension) {
      if (!dimension || dimension !== 'height') {
        this._checkAdaptiveState();
      }
    }
  }, {
    key: "_checkAdaptiveState",
    value: function _checkAdaptiveState() {
      var oldState = this._isInAdaptiveState;
      this._isInAdaptiveState = this._isSmallScreen();

      if (oldState !== this._isInAdaptiveState) {
        this.toggleDrawer(!this._isInAdaptiveState, true);

        this._raiseAdaptiveStateChanged(this._isInAdaptiveState);
      }
    }
  }, {
    key: "_isSmallScreen",
    value: function _isSmallScreen() {
      return (0, _renderer.default)(window).width() <= ADAPTIVE_STATE_SCREEN_WIDTH;
    }
  }, {
    key: "_initActions",
    value: function _initActions() {
      this._actions = {
        onAdaptiveStateChanged: this._createActionByOption('onAdaptiveStateChanged')
      };
    }
  }, {
    key: "_raiseAdaptiveStateChanged",
    value: function _raiseAdaptiveStateChanged(enabled) {
      this._actions.onAdaptiveStateChanged({
        enabled: enabled
      });
    }
  }, {
    key: "_getDefaultOptions",
    value: function _getDefaultOptions() {
      return (0, _extend.extend)(_get(_getPrototypeOf(FileManagerAdaptivityControl.prototype), "_getDefaultOptions", this).call(this), {
        drawerTemplate: null,
        contentTemplate: null,
        onAdaptiveStateChanged: null
      });
    }
  }, {
    key: "_optionChanged",
    value: function _optionChanged(args) {
      var name = args.name;

      switch (name) {
        case 'drawerTemplate':
        case 'contentTemplate':
          this.repaint();
          break;

        case 'onAdaptiveStateChanged':
          this._actions[name] = this._createActionByOption(name);
          break;

        default:
          _get(_getPrototypeOf(FileManagerAdaptivityControl.prototype), "_optionChanged", this).call(this, args);

      }
    }
  }, {
    key: "isInAdaptiveState",
    value: function isInAdaptiveState() {
      return this._isInAdaptiveState;
    }
  }, {
    key: "toggleDrawer",
    value: function toggleDrawer(showing, skipAnimation) {
      this._drawer.option('animationEnabled', !skipAnimation);

      this._drawer.toggle(showing);

      var isSplitterActive = this._drawer.option('opened') && !this.isInAdaptiveState();

      this._splitter.toggleState(isSplitterActive);
    }
  }]);

  return FileManagerAdaptivityControl;
}(_ui.default);

var _default = FileManagerAdaptivityControl;
exports.default = _default;
module.exports = exports.default;