#version 430 core

layout (location = 0) in vec4 position;
layout (location = 1) in vec2 inTextureCoordinate;

out vec2 textureCoordinate;

uniform mat4 mvpMatrix;

void main(void)
{
gl_Position = mvpMatrix * position;
textureCoordinate = inTextureCoordinate;
}
