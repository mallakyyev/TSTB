"use strict";

exports.groupBy = exports.find = exports.merge = exports.normalizeIndexes = exports.removeDuplicates = exports.intersection = exports.inArray = exports.wrapToArray = exports.isEmpty = void 0;

var _type = require("./type");

var _iterator = require("./iterator");

var _object = require("./object");

var _config = _interopRequireDefault(require("../config"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _toConsumableArray(arr) { return _arrayWithoutHoles(arr) || _iterableToArray(arr) || _unsupportedIterableToArray(arr) || _nonIterableSpread(); }

function _nonIterableSpread() { throw new TypeError("Invalid attempt to spread non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); }

function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }

function _iterableToArray(iter) { if (typeof Symbol !== "undefined" && Symbol.iterator in Object(iter)) return Array.from(iter); }

function _arrayWithoutHoles(arr) { if (Array.isArray(arr)) return _arrayLikeToArray(arr); }

function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) { arr2[i] = arr[i]; } return arr2; }

function ownKeys(object, enumerableOnly) { var keys = Object.keys(object); if (Object.getOwnPropertySymbols) { var symbols = Object.getOwnPropertySymbols(object); if (enumerableOnly) symbols = symbols.filter(function (sym) { return Object.getOwnPropertyDescriptor(object, sym).enumerable; }); keys.push.apply(keys, symbols); } return keys; }

function _objectSpread(target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i] != null ? arguments[i] : {}; if (i % 2) { ownKeys(Object(source), true).forEach(function (key) { _defineProperty(target, key, source[key]); }); } else if (Object.getOwnPropertyDescriptors) { Object.defineProperties(target, Object.getOwnPropertyDescriptors(source)); } else { ownKeys(Object(source)).forEach(function (key) { Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key)); }); } } return target; }

function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }

var isEmpty = function isEmpty(entity) {
  return Array.isArray(entity) && !entity.length;
};

exports.isEmpty = isEmpty;

var wrapToArray = function wrapToArray(entity) {
  return Array.isArray(entity) ? entity : [entity];
};

exports.wrapToArray = wrapToArray;

var inArray = function inArray(value, object) {
  if (!object) {
    return -1;
  }

  var array = Array.isArray(object) ? object : object.toArray();
  return array.indexOf(value);
};

exports.inArray = inArray;

var intersection = function intersection(a, b) {
  if (!Array.isArray(a) || a.length === 0 || !Array.isArray(b) || b.length === 0) {
    return [];
  }

  var result = [];
  (0, _iterator.each)(a, function (_, value) {
    var index = inArray(value, b);

    if (index !== -1) {
      result.push(value);
    }
  });
  return result;
};

exports.intersection = intersection;

var removeDuplicates = function removeDuplicates(from, what) {
  if (!Array.isArray(from) || from.length === 0) {
    return [];
  }

  if (!Array.isArray(what) || what.length === 0) {
    return from.slice();
  }

  var result = [];
  (0, _iterator.each)(from, function (_, value) {
    var index = inArray(value, what);

    if (index === -1) {
      result.push(value);
    }
  });
  return result;
};

exports.removeDuplicates = removeDuplicates;

var normalizeIndexes = function normalizeIndexes(items, indexParameterName, currentItem, needIndexCallback) {
  var indexedItems = {};
  var parameterIndex = 0;
  var useLegacyVisibleIndex = (0, _config.default)().useLegacyVisibleIndex;
  (0, _iterator.each)(items, function (index, item) {
    index = item[indexParameterName];

    if (index >= 0) {
      indexedItems[index] = indexedItems[index] || [];

      if (item === currentItem) {
        indexedItems[index].unshift(item);
      } else {
        indexedItems[index].push(item);
      }
    } else {
      item[indexParameterName] = undefined;
    }
  });

  if (!useLegacyVisibleIndex) {
    (0, _iterator.each)(items, function () {
      if (!(0, _type.isDefined)(this[indexParameterName]) && (!needIndexCallback || needIndexCallback(this))) {
        while (indexedItems[parameterIndex]) {
          parameterIndex++;
        }

        indexedItems[parameterIndex] = [this];
        parameterIndex++;
      }
    });
  }

  parameterIndex = 0;
  (0, _object.orderEach)(indexedItems, function (index, items) {
    (0, _iterator.each)(items, function () {
      if (index >= 0) {
        this[indexParameterName] = parameterIndex++;
      }
    });
  });

  if (useLegacyVisibleIndex) {
    (0, _iterator.each)(items, function () {
      if (!(0, _type.isDefined)(this[indexParameterName]) && (!needIndexCallback || needIndexCallback(this))) {
        this[indexParameterName] = parameterIndex++;
      }
    });
  }

  return parameterIndex;
};

exports.normalizeIndexes = normalizeIndexes;

var merge = function merge(array1, array2) {
  for (var i = 0; i < array2.length; i++) {
    array1[array1.length] = array2[i];
  }

  return array1;
};

exports.merge = merge;

var find = function find(array, condition) {
  for (var i = 0; i < array.length; i++) {
    if (condition(array[i])) {
      return array[i];
    }
  }
};

exports.find = find;

var groupBy = function groupBy(array, cb) {
  return array.reduce(function (result, item) {
    return _objectSpread(_objectSpread({}, result), {}, _defineProperty({}, cb(item), [].concat(_toConsumableArray(result[cb(item)] || []), [item])));
  }, {});
};

exports.groupBy = groupBy;