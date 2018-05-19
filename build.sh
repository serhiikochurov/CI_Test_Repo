#!/bin/sh

BUILD_DIR=$HOME'/Desktop/CI_Test_Repo/'
CI_ANDROID_STUDIO_BUILD_PATH=$BUILD_DIR'Build'

export CI_ANDROID_STUDIO_BUILD_PATH

rm -rf $CI_ANDROID_STUDIO_BUILD_PATH

/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -nographics -executeMethod CustomBuild.BuildAndroidStudioProject -logFile /dev/stdout

gradle build -p 'Build/CI_TestProject/'
mv 'Build/CI_TestProject/build/outputs/apk/CI_TestProject-release.apk' './'
