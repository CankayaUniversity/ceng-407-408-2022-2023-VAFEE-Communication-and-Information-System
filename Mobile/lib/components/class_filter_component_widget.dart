import '/backend/backend.dart';
import '/flutter_flow/flutter_flow_drop_down.dart';
import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import '/flutter_flow/flutter_flow_widgets.dart';
import '/flutter_flow/form_field_controller.dart';
import 'package:flutter/material.dart';
import 'package:flutter/scheduler.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'class_filter_component_model.dart';
export 'class_filter_component_model.dart';

class ClassFilterComponentWidget extends StatefulWidget {
  const ClassFilterComponentWidget({Key? key}) : super(key: key);

  @override
  _ClassFilterComponentWidgetState createState() =>
      _ClassFilterComponentWidgetState();
}

class _ClassFilterComponentWidgetState
    extends State<ClassFilterComponentWidget> {
  late ClassFilterComponentModel _model;

  @override
  void setState(VoidCallback callback) {
    super.setState(callback);
    _model.onUpdate();
  }

  @override
  void initState() {
    super.initState();
    _model = createModel(context, () => ClassFilterComponentModel());

    // On component load action.
    SchedulerBinding.instance.addPostFrameCallback((_) async {
      context.pushNamed(
        'classFilterpage',
        queryParameters: {
          'filterDepartment': serializeParam(
            _model.stateValue1,
            ParamType.String,
          ),
          'filterTerm': serializeParam(
            _model.stateValue2,
            ParamType.String,
          ),
        }.withoutNulls,
        extra: <String, dynamic>{
          kTransitionInfoKey: TransitionInfo(
            hasTransition: true,
            transitionType: PageTransitionType.fade,
            duration: Duration(milliseconds: 0),
          ),
        },
      );
    });
  }

  @override
  void dispose() {
    _model.maybeDispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    context.watch<FFAppState>();

    return Column(
      mainAxisSize: MainAxisSize.max,
      children: [
        Padding(
          padding: EdgeInsetsDirectional.fromSTEB(20.0, 20.0, 20.0, 12.0),
          child: StreamBuilder<List<ClassesRecord>>(
            stream: queryClassesRecord(),
            builder: (context, snapshot) {
              // Customize what your widget looks like when it's loading.
              if (!snapshot.hasData) {
                return Center(
                  child: SizedBox(
                    width: 50.0,
                    height: 50.0,
                    child: CircularProgressIndicator(
                      color: FlutterFlowTheme.of(context).primary,
                    ),
                  ),
                );
              }
              List<ClassesRecord> stateClassesRecordList = snapshot.data!;
              return FlutterFlowDropDown<String>(
                controller: _model.stateValueController1 ??=
                    FormFieldController<String>(null),
                options: FFAppState().Departments,
                onChanged: (val) => setState(() => _model.stateValue1 = val),
                width: double.infinity,
                height: 56.0,
                textStyle: FlutterFlowTheme.of(context).bodyMedium,
                hintText: 'Department',
                icon: Icon(
                  Icons.keyboard_arrow_down_rounded,
                  color: FlutterFlowTheme.of(context).secondaryText,
                  size: 15.0,
                ),
                fillColor: FlutterFlowTheme.of(context).secondaryBackground,
                elevation: 2.0,
                borderColor: FlutterFlowTheme.of(context).alternate,
                borderWidth: 2.0,
                borderRadius: 8.0,
                margin: EdgeInsetsDirectional.fromSTEB(20.0, 4.0, 12.0, 4.0),
                hidesUnderline: true,
                isSearchable: false,
              );
            },
          ),
        ),
        Padding(
          padding: EdgeInsetsDirectional.fromSTEB(20.0, 0.0, 20.0, 12.0),
          child: FlutterFlowDropDown<String>(
            controller: _model.stateValueController2 ??=
                FormFieldController<String>(
              _model.stateValue2 ??= 'Term',
            ),
            options: FFAppState().term,
            onChanged: (val) => setState(() => _model.stateValue2 = val),
            width: double.infinity,
            height: 56.0,
            textStyle: FlutterFlowTheme.of(context).bodyMedium,
            hintText: 'Term',
            icon: Icon(
              Icons.keyboard_arrow_down_rounded,
              color: FlutterFlowTheme.of(context).secondaryText,
              size: 15.0,
            ),
            fillColor: FlutterFlowTheme.of(context).secondaryBackground,
            elevation: 2.0,
            borderColor: FlutterFlowTheme.of(context).alternate,
            borderWidth: 2.0,
            borderRadius: 8.0,
            margin: EdgeInsetsDirectional.fromSTEB(20.0, 4.0, 12.0, 4.0),
            hidesUnderline: true,
            isSearchable: false,
          ),
        ),
        Padding(
          padding: EdgeInsetsDirectional.fromSTEB(20.0, 0.0, 20.0, 12.0),
          child: FlutterFlowDropDown<String>(
            controller: _model.stateValueController3 ??=
                FormFieldController<String>(
              _model.stateValue3 ??= 'Approval',
            ),
            options: ['Approval', 'Elective'],
            onChanged: (val) => setState(() => _model.stateValue3 = val),
            width: double.infinity,
            height: 56.0,
            textStyle: FlutterFlowTheme.of(context).bodyMedium,
            hintText: 'Approval',
            icon: Icon(
              Icons.keyboard_arrow_down_rounded,
              color: FlutterFlowTheme.of(context).secondaryText,
              size: 15.0,
            ),
            fillColor: FlutterFlowTheme.of(context).secondaryBackground,
            elevation: 2.0,
            borderColor: FlutterFlowTheme.of(context).alternate,
            borderWidth: 2.0,
            borderRadius: 8.0,
            margin: EdgeInsetsDirectional.fromSTEB(20.0, 4.0, 12.0, 4.0),
            hidesUnderline: true,
            isSearchable: false,
          ),
        ),
        FFButtonWidget(
          onPressed: () async {
            context.pushNamed(
              'classFilterpage',
              queryParameters: {
                'filterDepartment': serializeParam(
                  '',
                  ParamType.String,
                ),
                'filterTerm': serializeParam(
                  _model.stateValue2,
                  ParamType.String,
                ),
              }.withoutNulls,
              extra: <String, dynamic>{
                kTransitionInfoKey: TransitionInfo(
                  hasTransition: true,
                  transitionType: PageTransitionType.fade,
                  duration: Duration(milliseconds: 0),
                ),
              },
            );
          },
          text: 'Ok',
          icon: Icon(
            Icons.done_outline,
            size: 15.0,
          ),
          options: FFButtonOptions(
            height: 40.0,
            padding: EdgeInsetsDirectional.fromSTEB(24.0, 0.0, 24.0, 0.0),
            iconPadding: EdgeInsetsDirectional.fromSTEB(0.0, 0.0, 0.0, 0.0),
            color: FlutterFlowTheme.of(context).primary,
            textStyle: FlutterFlowTheme.of(context).titleSmall.override(
                  fontFamily: 'Lexend Deca',
                  color: Colors.white,
                ),
            elevation: 3.0,
            borderSide: BorderSide(
              color: Colors.transparent,
              width: 1.0,
            ),
            borderRadius: BorderRadius.circular(8.0),
          ),
        ),
      ],
    );
  }
}
