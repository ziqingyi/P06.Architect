
#include "pch.h"


extern "C" __declspec(dllexport) int Add(int x, int y)
{
#ifdef _DEBUG
	return x+y;
#else
	return y;
#endif
}