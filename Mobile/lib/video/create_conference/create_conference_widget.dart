import '/auth/firebase_auth/auth_util.dart';
import '/backend/backend.dart';
import '/flutter_flow/flutter_flow_icon_button.dart';
import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import '/flutter_flow/flutter_flow_widgets.dart';
import '/flutter_flow/random_data_util.dart' as random_data;
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:easy_debounce/easy_debounce.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'create_conference_model.dart';
export 'create_conference_model.dart';

class CreateConferenceWidget extends StatefulWidget {
  const CreateConferenceWidget({
    Key? key,
    String? conferenceIDrand,
  })  : this.conferenceIDrand = conferenceIDrand ?? 'empty',
        super(key: key);

  final String conferenceIDrand;

  @override
  _CreateConferenceWidgetState createState() => _CreateConferenceWidgetState();
}

class _CreateConferenceWidgetState extends State<CreateConferenceWidget> {
  late CreateConferenceModel _model;

  final scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  void initState() {
    super.initState();
    _model = createModel(context, () => CreateConferenceModel());

    _model.textController1 ??= TextEditingController();
    _model.textController2 ??= TextEditingController(
        text: valueOrDefault<String>(
      random_data.randomInteger(100000000, 999999999).toString(),
      '-1',
    ));
    _model.textController3 ??= TextEditingController();
  }

  @override
  void dispose() {
    _model.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    context.watch<FFAppState>();

    return GestureDetector(
      onTap: () => FocusScope.of(context).requestFocus(_model.unfocusNode),
      child: Scaffold(
        key: scaffoldKey,
        backgroundColor: FlutterFlowTheme.of(context).background,
        appBar: AppBar(
          backgroundColor: FlutterFlowTheme.of(context).primary,
          automaticallyImplyLeading: false,
          leading: FlutterFlowIconButton(
            borderColor: Colors.transparent,
            borderRadius: 30.0,
            borderWidth: 1.0,
            buttonSize: 60.0,
            icon: Icon(
              Icons.arrow_back_rounded,
              color: Colors.white,
              size: 30.0,
            ),
            onPressed: () async {
              context.pop();
            },
          ),
          title: Text(
            'Conference Page',
            style: FlutterFlowTheme.of(context).headlineMedium.override(
                  fontFamily: 'Lexend Deca',
                  color: Colors.white,
                  fontSize: 22.0,
                ),
          ),
          actions: [],
          centerTitle: false,
          elevation: 2.0,
        ),
        body: SafeArea(
          top: true,
          child: Column(
            mainAxisSize: MainAxisSize.max,
            children: [
              Padding(
                padding: EdgeInsetsDirectional.fromSTEB(10.0, 20.0, 10.0, 10.0),
                child: Container(
                  width: double.infinity,
                  height: 50.0,
                  decoration: BoxDecoration(
                    color: FlutterFlowTheme.of(context).primaryBackground,
                    borderRadius: BorderRadius.circular(25.0),
                  ),
                  child: Padding(
                    padding:
                        EdgeInsetsDirectional.fromSTEB(12.0, 0.0, 20.0, 0.0),
                    child: TextFormField(
                      controller: _model.textController1,
                      onChanged: (_) => EasyDebounce.debounce(
                        '_model.textController1',
                        Duration(milliseconds: 2000),
                        () async {
                          setState(() {
                            _model.randConfID = random_data.randomString(
                              10,
                              20,
                              true,
                              true,
                              true,
                            );
                          });
                        },
                      ),
                      obscureText: false,
                      decoration: InputDecoration(
                        labelText: 'Conference Name',
                        labelStyle: FlutterFlowTheme.of(context).bodyMedium,
                        hintText: 'Conference Name',
                        enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                        focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                        errorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                        focusedErrorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                      ),
                      style: FlutterFlowTheme.of(context).bodyMedium.override(
                            fontFamily: 'Lexend Deca',
                            color: FlutterFlowTheme.of(context).tertiary,
                          ),
                      keyboardType: TextInputType.emailAddress,
                      validator:
                          _model.textController1Validator.asValidator(context),
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsetsDirectional.fromSTEB(10.0, 20.0, 10.0, 10.0),
                child: Container(
                  width: double.infinity,
                  height: 50.0,
                  decoration: BoxDecoration(
                    color: FlutterFlowTheme.of(context).primaryBackground,
                    borderRadius: BorderRadius.circular(25.0),
                  ),
                  child: Padding(
                    padding:
                        EdgeInsetsDirectional.fromSTEB(12.0, 0.0, 20.0, 0.0),
                    child: TextFormField(
                      controller: _model.textController2,
                      onFieldSubmitted: (_) async {
                        final conferencesCreateData = {
                          ...createConferencesRecordData(
                            confUid: random_data
                                .randomInteger(100000000, 999999999)
                                .toString(),
                            confTitle: _model.textController1.text,
                          ),
                          'conf_startdate': FieldValue.serverTimestamp(),
                        };
                        await ConferencesRecord.collection
                            .doc()
                            .set(conferencesCreateData);
                      },
                      readOnly: true,
                      obscureText: false,
                      decoration: InputDecoration(
                        labelText: 'Conference ID',
                        labelStyle: FlutterFlowTheme.of(context).bodyMedium,
                        hintText: 'Conference ID',
                        enabledBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                        focusedBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                        errorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                        focusedErrorBorder: OutlineInputBorder(
                          borderSide: BorderSide(
                            color: Color(0x00000000),
                            width: 1.0,
                          ),
                          borderRadius: const BorderRadius.only(
                            topLeft: Radius.circular(4.0),
                            topRight: Radius.circular(4.0),
                          ),
                        ),
                      ),
                      style: FlutterFlowTheme.of(context).bodyMedium.override(
                            fontFamily: 'Lexend Deca',
                            color: FlutterFlowTheme.of(context).tertiary,
                          ),
                      keyboardType: TextInputType.emailAddress,
                      validator:
                          _model.textController2Validator.asValidator(context),
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsetsDirectional.fromSTEB(0.0, 10.0, 0.0, 10.0),
                child: FFButtonWidget(
                  onPressed: () async {
                    setState(() {
                      _model.randConfID = random_data
                          .randomInteger(100000000, 999999999)
                          .toString();
                    });

                    final conferencesCreateData = createConferencesRecordData(
                      confTitle: _model.textController1.text,
                      confStartdate: getCurrentTimestamp,
                      confUid: _model.textController2.text,
                    );
                    await ConferencesRecord.collection
                        .doc()
                        .set(conferencesCreateData);

                    context.pushNamed(
                      'ConferencePage',
                      queryParameters: {
                        'conferenceID': serializeParam(
                          _model.textController2.text,
                          ParamType.String,
                        ),
                        'username': serializeParam(
                          currentUserEmail,
                          ParamType.String,
                        ),
                        'useruid': serializeParam(
                          currentUserUid,
                          ParamType.String,
                        ),
                      }.withoutNulls,
                    );
                  },
                  text: 'Create Conference',
                  options: FFButtonOptions(
                    height: 40.0,
                    padding:
                        EdgeInsetsDirectional.fromSTEB(24.0, 0.0, 24.0, 0.0),
                    iconPadding:
                        EdgeInsetsDirectional.fromSTEB(0.0, 0.0, 0.0, 0.0),
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
              ),
              Padding(
                padding: EdgeInsetsDirectional.fromSTEB(20.0, 0.0, 20.0, 0.0),
                child: TextFormField(
                  controller: _model.textController3,
                  autofocus: true,
                  obscureText: false,
                  decoration: InputDecoration(
                    labelText: '    Give an ID',
                    hintStyle: FlutterFlowTheme.of(context).labelMedium,
                    enabledBorder: UnderlineInputBorder(
                      borderSide: BorderSide(
                        color: FlutterFlowTheme.of(context).alternate,
                        width: 2.0,
                      ),
                      borderRadius: BorderRadius.circular(20.0),
                    ),
                    focusedBorder: UnderlineInputBorder(
                      borderSide: BorderSide(
                        color: FlutterFlowTheme.of(context).primary,
                        width: 2.0,
                      ),
                      borderRadius: BorderRadius.circular(20.0),
                    ),
                    errorBorder: UnderlineInputBorder(
                      borderSide: BorderSide(
                        color: FlutterFlowTheme.of(context).error,
                        width: 2.0,
                      ),
                      borderRadius: BorderRadius.circular(20.0),
                    ),
                    focusedErrorBorder: UnderlineInputBorder(
                      borderSide: BorderSide(
                        color: FlutterFlowTheme.of(context).error,
                        width: 2.0,
                      ),
                      borderRadius: BorderRadius.circular(20.0),
                    ),
                    filled: true,
                  ),
                  style: FlutterFlowTheme.of(context).bodyMedium,
                  validator:
                      _model.textController3Validator.asValidator(context),
                ),
              ),
              Padding(
                padding: EdgeInsetsDirectional.fromSTEB(0.0, 10.0, 0.0, 0.0),
                child: StreamBuilder<List<ConferencesRecord>>(
                  stream: queryConferencesRecord(
                    queryBuilder: (conferencesRecord) =>
                        conferencesRecord.where('conf_uid',
                            isEqualTo: _model.textController3.text),
                    singleRecord: true,
                  ),
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
                    List<ConferencesRecord> buttonConferencesRecordList =
                        snapshot.data!;
                    final buttonConferencesRecord =
                        buttonConferencesRecordList.isNotEmpty
                            ? buttonConferencesRecordList.first
                            : null;
                    return FFButtonWidget(
                      onPressed: () async {
                        context.pushNamed(
                          'ConferencePage',
                          queryParameters: {
                            'conferenceID': serializeParam(
                              _model.textController3.text,
                              ParamType.String,
                            ),
                            'username': serializeParam(
                              currentUserEmail,
                              ParamType.String,
                            ),
                            'useruid': serializeParam(
                              currentUserUid,
                              ParamType.String,
                            ),
                          }.withoutNulls,
                        );
                      },
                      text: 'Join Conference',
                      options: FFButtonOptions(
                        height: 40.0,
                        padding: EdgeInsetsDirectional.fromSTEB(
                            24.0, 0.0, 24.0, 0.0),
                        iconPadding:
                            EdgeInsetsDirectional.fromSTEB(0.0, 0.0, 0.0, 0.0),
                        color: FlutterFlowTheme.of(context).primary,
                        textStyle:
                            FlutterFlowTheme.of(context).titleSmall.override(
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
                    );
                  },
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
