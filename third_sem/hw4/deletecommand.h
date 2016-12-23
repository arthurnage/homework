#pragma once
#include "command.h"

class DeleteCommand : public Command
{
public:
    DeleteCommand(QGraphicsLineItem *newLine);

    ~DeleteCommand();

    /// Sets line invisible.
    void act() override;

    /// Sets line visible.
    void react() override;

private:
    QGraphicsLineItem *deletedLine;
};
