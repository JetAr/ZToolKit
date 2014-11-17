#pragma once

/*

History:
//z 2014-11-17 15:06:37 L.44 '32003 BG57IV3@XCL T1139317397.K.F1711917868
0.00.01
    1. 从mpc中摘录出来，新增了对这些编译器的定义 vc 2013/update4 2005 2003 2002 vc6sp6/vc6 vc5
*/

#if defined(_MSC_VER)
    #if _MSC_VER == 1800
		#if (_MSC_FULL_VER == 180031101)
			#define VERSION_COMPILER    L"MSVC 2013 Update 4"
		#elif (_MSC_FULL_VER == 180030723)
			#define VERSION_COMPILER    L"MSVC 2013 Update 3"
        #elif (_MSC_FULL_VER == 180030501)
            #define VERSION_COMPILER    L"MSVC 2013 Update 2"
        #elif (_MSC_FULL_VER < 180021005)
            #define VERSION_COMPILER    L"MSVC 2013 Preview/Beta/RC"
        #else
            #define VERSION_COMPILER    L"MSVC 2013"
        #endif
    #elif _MSC_VER == 1700
        #if (_MSC_FULL_VER == 170061030)
            #define VERSION_COMPILER    L"MSVC 2012 Update 4"
        #elif (_MSC_FULL_VER == 170060610)
            #define VERSION_COMPILER    L"MSVC 2012 Update 3"
        #elif (_MSC_FULL_VER == 170060315)
            #define VERSION_COMPILER    L"MSVC 2012 Update 2"
        #elif (_MSC_FULL_VER == 170051106)
            #define VERSION_COMPILER    L"MSVC 2012 Update 1"
        #elif (_MSC_FULL_VER < 170050727)
            #define VERSION_COMPILER    L"MSVC 2012 Beta/RC/PR"
        #else
            #define VERSION_COMPILER    L"MSVC 2012"
        #endif
    #elif _MSC_VER == 1600
        #if (_MSC_FULL_VER >= 160040219)
            #define VERSION_COMPILER    L"MSVC 2010 SP1"
        #else
            #define VERSION_COMPILER    L"MSVC 2010"
        #endif
    #elif _MSC_VER == 1500
        #if (_MSC_FULL_VER >= 150030729)
            #define VERSION_COMPILER    L"MSVC 2008 SP1"
        #else
            #define VERSION_COMPILER    L"MSVC 2008"
        #endif
	#elif _MSC_VER == 1400
		#if (_MSC_FULL_VER >= 140050727 )
			#define VERSION_COMPILER    L"MSVC 2005 SP1"
		#else
			#define VERSION_COMPILER	L"MSVC 2005"
		#endif
	#elif _MSC_VER == 1310
		#define VERSION_COMPILER	L"MSVC 2003"
	#elif _MSC_VER == 1300
		#define VERSION_COMPILER	L"MSVC 2002"
	#elif _MSC_VER == 1200
		#if (_MSC_FULL_VER >= 12008804)
			#define VERSION_COMPILER	L"MSVC 6.0 SP6"
		#else
			#define VERSION_COMPILER	L"MSVC 6.0"
		#endif
	#elif _MSC_VER == 1100
		#define VERSION_COMPILER	L"MSVC 5.0"
    #else
        #define VERSION_COMPILER    L"MSVC (version unknown)"
    #endif
#else
    #define VERSION_COMPILER        L"(Unknown compiler)"
#endif
