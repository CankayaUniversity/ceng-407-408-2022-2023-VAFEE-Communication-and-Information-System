import 'package:flutter/material.dart';
import '/backend/backend.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'flutter_flow/flutter_flow_util.dart';

class FFAppState extends ChangeNotifier {
  static final FFAppState _instance = FFAppState._internal();

  factory FFAppState() {
    return _instance;
  }

  FFAppState._internal();

  Future initializePersistedState() async {
    prefs = await SharedPreferences.getInstance();
    _safeInit(() {
      _categoryControl =
          prefs.getString('ff_categoryControl') ?? _categoryControl;
    });
  }

  void update(VoidCallback callback) {
    callback();
    notifyListeners();
  }

  late SharedPreferences prefs;

  DateTime? _selectedDate = DateTime.fromMillisecondsSinceEpoch(1682024400000);
  DateTime? get selectedDate => _selectedDate;
  set selectedDate(DateTime? _value) {
    _selectedDate = _value;
  }

  String _categoryControl = '';
  String get categoryControl => _categoryControl;
  set categoryControl(String _value) {
    _categoryControl = _value;
    prefs.setString('ff_categoryControl', _value);
  }

  List<String> _Departments = [
    'Computer Engineering',
    'Industrial Engineering',
    'Computer Science',
    'Electrical Engineering',
    'Mechanical Engineering',
    'Physics',
    'Chemistry',
    'Biology',
    'Mathematics',
    'English',
    'History',
    'Psychology'
  ];
  List<String> get Departments => _Departments;
  set Departments(List<String> _value) {
    _Departments = _value;
  }

  void addToDepartments(String _value) {
    _Departments.add(_value);
  }

  void removeFromDepartments(String _value) {
    _Departments.remove(_value);
  }

  void removeAtIndexFromDepartments(int _index) {
    _Departments.removeAt(_index);
  }

  void updateDepartmentsAtIndex(
    int _index,
    String Function(String) updateFn,
  ) {
    _Departments[_index] = updateFn(_Departments[_index]);
  }

  List<String> _term = [
    'Term 1',
    'Term 2',
    'Term 3',
    'Term 4',
    'Term 5',
    'Term 6',
    'Term 7',
    'Term 8'
  ];
  List<String> get term => _term;
  set term(List<String> _value) {
    _term = _value;
  }

  void addToTerm(String _value) {
    _term.add(_value);
  }

  void removeFromTerm(String _value) {
    _term.remove(_value);
  }

  void removeAtIndexFromTerm(int _index) {
    _term.removeAt(_index);
  }

  void updateTermAtIndex(
    int _index,
    String Function(String) updateFn,
  ) {
    _term[_index] = updateFn(_term[_index]);
  }
}

LatLng? _latLngFromString(String? val) {
  if (val == null) {
    return null;
  }
  final split = val.split(',');
  final lat = double.parse(split.first);
  final lng = double.parse(split.last);
  return LatLng(lat, lng);
}

void _safeInit(Function() initializeField) {
  try {
    initializeField();
  } catch (_) {}
}

Future _safeInitAsync(Function() initializeField) async {
  try {
    await initializeField();
  } catch (_) {}
}
