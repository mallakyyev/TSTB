"use strict";

exports.default = void 0;

var _renderer = _interopRequireDefault(require("../../core/renderer"));

var _ui = _interopRequireDefault(require("../widget/ui.widget"));

var _popover = _interopRequireDefault(require("../popover"));

var _diagram = require("./diagram.importer");

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

var DIAGRAM_CONTEXT_TOOLBOX_TARGET_CLASS = 'dx-diagram-context-toolbox-target';
var DIAGRAM_CONTEXT_TOOLBOX_CLASS = 'dx-diagram-context-toolbox';
var DIAGRAM_TOUCH_CONTEXT_TOOLBOX_CLASS = 'dx-diagram-touch-context-toolbox';
var DIAGRAM_CONTEXT_TOOLBOX_CONTENT_CLASS = 'dx-diagram-context-toolbox-content';

var DiagramContextToolbox = /*#__PURE__*/function (_Widget) {
  _inherits(DiagramContextToolbox, _Widget);

  var _super = _createSuper(DiagramContextToolbox);

  function DiagramContextToolbox() {
    _classCallCheck(this, DiagramContextToolbox);

    return _super.apply(this, arguments);
  }

  _createClass(DiagramContextToolbox, [{
    key: "_init",
    value: function _init() {
      _get(_getPrototypeOf(DiagramContextToolbox.prototype), "_init", this).call(this);

      this._onShownAction = this._createActionByOption('onShown');
      this._popoverPositionData = [{
        my: {
          x: 'center',
          y: 'top'
        },
        at: {
          x: 'center',
          y: 'bottom'
        },
        offset: {
          x: 0,
          y: 5
        }
      }, {
        my: {
          x: 'right',
          y: 'center'
        },
        at: {
          x: 'left',
          y: 'center'
        },
        offset: {
          x: -5,
          y: 0
        }
      }, {
        my: {
          x: 'center',
          y: 'bottom'
        },
        at: {
          x: 'center',
          y: 'top'
        },
        offset: {
          x: 0,
          y: -5
        }
      }, {
        my: {
          x: 'left',
          y: 'center'
        },
        at: {
          x: 'right',
          y: 'center'
        },
        offset: {
          x: 5,
          y: 0
        }
      }];
    }
  }, {
    key: "_initMarkup",
    value: function _initMarkup() {
      _get(_getPrototypeOf(DiagramContextToolbox.prototype), "_initMarkup", this).call(this);

      this._$popoverTargetElement = (0, _renderer.default)('<div>').addClass(DIAGRAM_CONTEXT_TOOLBOX_TARGET_CLASS).appendTo(this.$element());
      var $popoverElement = (0, _renderer.default)('<div>').appendTo(this.$element());

      var _getDiagram = (0, _diagram.getDiagram)(),
          Browser = _getDiagram.Browser;

      var popoverClass = DIAGRAM_CONTEXT_TOOLBOX_CLASS;

      if (Browser.TouchUI) {
        popoverClass += ' ' + DIAGRAM_TOUCH_CONTEXT_TOOLBOX_CLASS;
      }

      this._popoverInstance = this._createComponent($popoverElement, _popover.default, {
        closeOnOutsideClick: false,
        container: this.$element(),
        elementAttr: {
          class: popoverClass
        }
      });
    }
  }, {
    key: "_show",
    value: function _show(x, y, side, category, callback) {
      this._popoverInstance.hide();

      var $content = (0, _renderer.default)('<div>').addClass(DIAGRAM_CONTEXT_TOOLBOX_CONTENT_CLASS);

      if (this.option('toolboxWidth') !== undefined) {
        $content.css('width', this.option('toolboxWidth'));
      }

      this._$popoverTargetElement.css({
        left: x + this._popoverPositionData[side].offset.x,
        top: y + this._popoverPositionData[side].offset.y
      }).show();

      this._popoverInstance.option({
        position: {
          my: this._popoverPositionData[side].my,
          at: this._popoverPositionData[side].at,
          of: this._$popoverTargetElement
        },
        contentTemplate: $content,
        onContentReady: function () {
          var _this = this;

          var $element = this.$element().find('.' + DIAGRAM_CONTEXT_TOOLBOX_CONTENT_CLASS);

          this._onShownAction({
            category: category,
            callback: callback,
            $element: $element,
            hide: function hide() {
              return _this._popoverInstance.hide();
            }
          });
        }.bind(this)
      });

      this._popoverInstance.show();
    }
  }, {
    key: "_hide",
    value: function _hide() {
      this._$popoverTargetElement.hide();

      this._popoverInstance.hide();
    }
  }]);

  return DiagramContextToolbox;
}(_ui.default);

var _default = DiagramContextToolbox;
exports.default = _default;
module.exports = exports.default;