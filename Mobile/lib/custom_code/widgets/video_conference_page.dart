// Automatic FlutterFlow imports
import '/backend/backend.dart';
import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import 'index.dart'; // Imports other custom widgets
import '/flutter_flow/custom_functions.dart'; // Imports custom functions
import 'package:flutter/material.dart';
// Begin custom widget code
// DO NOT REMOVE OR MODIFY THE CODE ABOVE!

import 'package:zego_uikit_prebuilt_video_conference/zego_uikit_prebuilt_video_conference.dart';
import 'dart:math';

class VideoConferencePage extends StatefulWidget {
  const VideoConferencePage({
    Key? key,
    this.width,
    this.height,
    required this.conferenceID,
    required this.username,
    required this.useruid,
  }) : super(key: key);

  final double? width;
  final double? height;
  final String conferenceID;
  final String username;
  final String useruid;

  @override
  _VideoConferencePageState createState() => _VideoConferencePageState();
}

class _VideoConferencePageState extends State<VideoConferencePage> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: ZegoUIKitPrebuiltVideoConference(
        appID:
            576740937, // Fill in the appID that you get from ZEGOCLOUD Admin Console.
        appSign:
            "4bc88b6152b9532ce95f5a3bda387ee41dfac203bfc439f1616d8994fe1feca6", // Fill in the appSign that you get from ZEGOCLOUD Admin Console.
        userID: widget.useruid,
        userName: "user_" + widget.username,
        conferenceID: widget.conferenceID,
        config: ZegoUIKitPrebuiltVideoConferenceConfig(),
      ),
    );
  }
}
