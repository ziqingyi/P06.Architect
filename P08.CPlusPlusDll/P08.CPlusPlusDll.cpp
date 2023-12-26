// P08.CPlusPlusDll.cpp : 定义 DLL 的导出函数。
//

#include "pch.h"
#include "framework.h"
#include "P08.CPlusPlusDll.h"


// 这是导出变量的一个示例
P08CPLUSPLUSDLL_API int nP08CPlusPlusDll=0;

// 这是导出函数的一个示例。
P08CPLUSPLUSDLL_API int fnP08CPlusPlusDll(void)
{
    return 0;
}

// 这是已导出类的构造函数。
CP08CPlusPlusDll::CP08CPlusPlusDll()
{
    return;
}
