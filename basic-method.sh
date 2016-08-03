#!/bin/bash
function divider()
{
    echo
    #echo "================================================华丽丽的风格线=============================================="
    echo "----------------------------------------------华丽丽的分隔线----------------------------------------------"
    echo
}

function get_first_device()
{
    export dev=`adb devices|grep device|awk '{print $1}'|sed '2!d'`
}

function check_device()
{
    has_device
    if [ "$dev" == "" ]; then
        get_first_device
    else
        dv=`adb devices|grep $dev`
        if [ "$dv" == "" ]; then
            get_first_device
        else    
            export dev=`adb devices |grep $dev|awk '{print $1}'|sed '1!d'`
        fi
    fi
    echo "--------------------------------------device is $dev ------------------------------"
}

function has_device()
{
	hasdevice=`adb devices|grep -v devices|grep 'device\|offline'`
	if [ "$hasdevice" == "" ]; then
		echo "==========================NO DEVICE=========================="
		    exit
	fi
}

function get_current_pkg()
{
    # adb shell "dumpsys window windows" | grep -E 'mFocusedApp' | awk -F/ '{print $1}' | awk -F"ActivityRecord" '{print $2}' | awk '{print $3}'
    adb shell "dumpsys window windows" | grep -E 'mCurrentFocus' | awk -F{ '{print $2}' | awk '{print $NF}' | awk -F/ '{print $1}' 
}