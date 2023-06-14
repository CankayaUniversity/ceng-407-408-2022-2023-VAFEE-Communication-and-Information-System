import '/backend/backend.dart';
import '/flutter_flow/flutter_flow_animations.dart';
import '/flutter_flow/flutter_flow_drop_down.dart';
import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import '/flutter_flow/form_field_controller.dart';
import 'package:flutter/material.dart';
import 'package:flutter/scheduler.dart';
import 'package:flutter_animate/flutter_animate.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class ClassFilterpageModel extends FlutterFlowModel {
  ///  Local state fields for this page.

  List<String> className = [];
  void addToClassName(String item) => className.add(item);
  void removeFromClassName(String item) => className.remove(item);
  void removeAtIndexFromClassName(int index) => className.removeAt(index);
  void updateClassNameAtIndex(int index, Function(String) updateFn) =>
      className[index] = updateFn(className[index]);

  String? department;

  String? term;

  String? approval;

  ///  State fields for stateful widgets in this page.

  // State field(s) for state widget.
  String? stateValue1;
  FormFieldController<String>? stateValueController1;
  // State field(s) for state widget.
  String? stateValue2;
  FormFieldController<String>? stateValueController2;
  // State field(s) for state widget.
  String? stateValue3;
  FormFieldController<String>? stateValueController3;

  /// Initialization and disposal methods.

  void initState(BuildContext context) {}

  void dispose() {}

  /// Action blocks are added here.

  /// Additional helper methods are added here.

}
