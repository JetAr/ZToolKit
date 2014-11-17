/******************************************************************************
*
* opengl version info
*
* Get_OpenGL_Info.c
*
* 
*
*                                       (c) BG57IV3#gmail.com 2014
*                                       https://github.com/as2120/ZToolKit
*
*
******************************************************************************/

#include <stdio.h>
#include <stdlib.h>
#include <GL/glut.h>

int main(int argc, char** argv)
{
	glutInit(&argc,argv);
	glutInitDisplayMode(GLUT_SINGLE|GLUT_RGB|GLUT_DEPTH);
	glutCreateWindow("OpenGL Version");

	const GLubyte * name = glGetString(GL_VENDOR);
	const GLubyte * biaoshifu = glGetString(GL_RENDERER);
	const GLubyte * OpenGLVersion = glGetString(GL_VERSION);
	//z const GLubyte * OpenGLExtVersion = glGetString(GL_EXTENSIONS);
	const GLubyte * gluVersion = gluGetString(GLU_VERSION);
	const GLubyte * gluExtensions = gluGetString(GLU_EXTENSIONS);
	//z const GLubyte * gluShadingLanguage = glGetString(GL_SHADING_LANGUAGE_VERSION);

	printf("OpenGL 基本信息\r\n");
	printf("渲染器：\t%s\n", biaoshifu);
	printf("厂商：\t\t%s\n", name);
	//z printf("扩展号：\t%s\n",OpenGLExtVersion);
	printf("版本号：\t%s\n",OpenGLVersion);
	printf("GLU版本：\t%s\n", gluVersion);
	//z printf("GLU版本：\t%s\n", gluShadingLanguage);
	printf("GLU.Ext：\t%s\n\r\n", gluExtensions);
	
	system("pause");

	//z getchar();

	return 0;
}
