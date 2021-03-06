/**
* @function cornerDetector_Demo.cpp
* @brief Demo code for detecting corners using OpenCV built-in functions
* @author OpenCV team
*/

#include "stdafx.h"
#include <iostream>
#include <opencv2/opencv.hpp>
#include <time.h>


using namespace cv;
using namespace std;
/**
* @function main
*/
int main(int argc, char** argv)
{
	VideoCapture vid;
	vid.open("videoplayback (4).mp4");
	Mat frame, frame2,frame_blur,frame_mask, frame_His,gradient;
		

	namedWindow("Video", WINDOW_AUTOSIZE);
	while (vid.isOpened())
	{
		vid >> frame;		
		if (frame.empty()) break;
		GaussianBlur(frame, frame_blur, Size(3, 3), -1);
		cvtColor(frame_blur, frame_blur, COLOR_BGR2GRAY);
		vid >> frame2;
		if (frame2.empty()) break;
		cvtColor(frame2, frame2, COLOR_BGR2GRAY);

		absdiff(frame_blur, frame2, frame_mask);

		threshold(frame_mask, frame_mask, 100, 255, THRESH_BINARY);

		morphologyEx(frame_mask, frame_mask, MORPH_CLOSE, Mat());
		
		vector< vector<Point> > contours;
		findContours(frame_mask, contours, CV_RETR_LIST, CV_CHAIN_APPROX_NONE);
		
		Mat mask = Mat::zeros(frame_mask.rows, frame_mask.cols, CV_8UC1);
		

		drawContours(frame_mask, contours, -1, Scalar(255), CV_FILLED);
		
		
		
		//if (frame_His.empty()) break;
		imshow("Video",frame_mask);
		
		char c = (char)waitKey(20);
		if (c == 27) break;
	}
	//waitKey(0);
	return 0;
}