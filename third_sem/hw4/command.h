#pragma once

#include <QGraphicsScene>
#include <QGraphicsLineItem>

class Command
{
public:
    virtual ~Command() = default;

    virtual void act() = 0;

    virtual void react() = 0;
protected:
    Command() = default;
};
