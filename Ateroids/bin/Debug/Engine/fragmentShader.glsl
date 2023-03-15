#version 430 core

in vec2 textureCoordinate;
uniform sampler2D textureObject;
out vec4 color;

void main(void)
{
	vec4 textColor = texelFetch(textureObject, ivec2(textureCoordinate.st), 0);
	if(textColor.a == 0)
		discard;
	color = textColor;
}