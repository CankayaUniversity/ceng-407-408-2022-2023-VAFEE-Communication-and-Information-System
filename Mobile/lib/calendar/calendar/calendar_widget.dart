import '/auth/firebase_auth/auth_util.dart';
import '/backend/backend.dart';
import '/flutter_flow/flutter_flow_calendar.dart';
import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import '/flutter_flow/custom_functions.dart' as functions;
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'calendar_model.dart';
export 'calendar_model.dart';

class CalendarWidget extends StatefulWidget {
  const CalendarWidget({Key? key}) : super(key: key);

  @override
  _CalendarWidgetState createState() => _CalendarWidgetState();
}

class _CalendarWidgetState extends State<CalendarWidget> {
  late CalendarModel _model;

  final scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  void initState() {
    super.initState();
    _model = createModel(context, () => CalendarModel());
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
        backgroundColor: FlutterFlowTheme.of(context).primaryBackground,
        floatingActionButton: FloatingActionButton(
          onPressed: () async {
            context.pushNamed(
              'EventBuilder',
              queryParameters: {
                'choosedDate': serializeParam(
                  FFAppState().selectedDate,
                  ParamType.DateTime,
                ),
              }.withoutNulls,
            );
          },
          backgroundColor: FlutterFlowTheme.of(context).primary,
          elevation: 8.0,
          child: Icon(
            Icons.add,
            color: Colors.black,
            size: 28.0,
          ),
        ),
        appBar: AppBar(
          backgroundColor: FlutterFlowTheme.of(context).primary,
          automaticallyImplyLeading: true,
          title: Text(
            'Calendar',
            textAlign: TextAlign.center,
            style: FlutterFlowTheme.of(context).headlineMedium.override(
                  fontFamily: 'Lexend Deca',
                  color: Colors.white,
                  fontSize: 22.0,
                ),
          ),
          actions: [],
          centerTitle: true,
          elevation: 2.0,
        ),
        body: SafeArea(
          top: true,
          child: Column(
            mainAxisSize: MainAxisSize.max,
            children: [
              FlutterFlowCalendar(
                color: FlutterFlowTheme.of(context).primary,
                weekFormat: false,
                weekStartsMonday: true,
                initialDate: FFAppState().selectedDate,
                onChange: (DateTimeRange? newSelectedDate) async {
                  _model.calendarSelectedDay = newSelectedDate;
                  setState(() {
                    FFAppState().selectedDate =
                        _model.calendarSelectedDay?.start;
                  });
                  setState(() {});
                },
                titleStyle: TextStyle(),
                dayOfWeekStyle: TextStyle(),
                dateStyle: TextStyle(),
                selectedDateStyle: TextStyle(),
                inactiveDateStyle: TextStyle(),
              ),
              StreamBuilder<List<TodoRecord>>(
                stream: queryTodoRecord(
                  queryBuilder: (todoRecord) => todoRecord
                      .where('date',
                          isGreaterThanOrEqualTo:
                              _model.calendarSelectedDay?.start)
                      .where('date',
                          isLessThanOrEqualTo: functions.futureDate(
                              FFAppState().selectedDate, 0, 0, 0, 1))
                      .where('created_by', isEqualTo: currentUserReference),
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
                  List<TodoRecord> listViewTodoRecordList = snapshot.data!;
                  return InkWell(
                    splashColor: Colors.transparent,
                    focusColor: Colors.transparent,
                    hoverColor: Colors.transparent,
                    highlightColor: Colors.transparent,
                    onTap: () async {
                      final _datePickedDate = await showDatePicker(
                        context: context,
                        initialDate: getCurrentTimestamp,
                        firstDate: getCurrentTimestamp,
                        lastDate: DateTime(2050),
                      );

                      TimeOfDay? _datePickedTime;
                      if (_datePickedDate != null) {
                        _datePickedTime = await showTimePicker(
                          context: context,
                          initialTime:
                              TimeOfDay.fromDateTime(getCurrentTimestamp),
                        );
                      }

                      if (_datePickedDate != null && _datePickedTime != null) {
                        setState(() {
                          _model.datePicked = DateTime(
                            _datePickedDate.year,
                            _datePickedDate.month,
                            _datePickedDate.day,
                            _datePickedTime!.hour,
                            _datePickedTime.minute,
                          );
                        });
                      }
                    },
                    child: ListView.builder(
                      padding: EdgeInsets.zero,
                      shrinkWrap: true,
                      scrollDirection: Axis.vertical,
                      itemCount: listViewTodoRecordList.length,
                      itemBuilder: (context, listViewIndex) {
                        final listViewTodoRecord =
                            listViewTodoRecordList[listViewIndex];
                        return InkWell(
                          splashColor: Colors.transparent,
                          focusColor: Colors.transparent,
                          hoverColor: Colors.transparent,
                          highlightColor: Colors.transparent,
                          onTap: () async {
                            context.pushNamed(
                              'EventDetails',
                              queryParameters: {
                                'docRef': serializeParam(
                                  listViewTodoRecord.reference,
                                  ParamType.DocumentReference,
                                ),
                                'description': serializeParam(
                                  '',
                                  ParamType.String,
                                ),
                                'status': serializeParam(
                                  '',
                                  ParamType.String,
                                ),
                                'taskName': serializeParam(
                                  '',
                                  ParamType.String,
                                ),
                              }.withoutNulls,
                            );
                          },
                          child: ListTile(
                            title: Text(
                              listViewTodoRecord.title,
                              style: FlutterFlowTheme.of(context).headlineSmall,
                            ),
                            subtitle: Text(
                              dateTimeFormat(
                                  'MMMMEEEEd', listViewTodoRecord.date!),
                              style: FlutterFlowTheme.of(context).titleSmall,
                            ),
                            trailing: Icon(
                              Icons.arrow_forward_ios,
                              color: FlutterFlowTheme.of(context).accent2,
                              size: 20.0,
                            ),
                            tileColor: FlutterFlowTheme.of(context)
                                .secondaryBackground,
                            dense: false,
                          ),
                        );
                      },
                    ),
                  );
                },
              ),
              StreamBuilder<List<TodoRecord>>(
                stream: queryTodoRecord(
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
                  List<TodoRecord> textTodoRecordList = snapshot.data!;
                  // Return an empty Container when the item does not exist.
                  if (snapshot.data!.isEmpty) {
                    return Container();
                  }
                  final textTodoRecord = textTodoRecordList.isNotEmpty
                      ? textTodoRecordList.first
                      : null;
                  return Text(
                    dateTimeFormat('yMd', textTodoRecord!.date!),
                    style: FlutterFlowTheme.of(context).bodyMedium,
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
