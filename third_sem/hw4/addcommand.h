#pragma once
#include "command.h"

class AddCommand : public Command
{
public:
    AddCommand(QGraphicsLineItem *newLine);

    ~AddCommand();

    /// Sets line invisible.
    void act() override;

    /// Sets line visible.
    void react() override;

private:
    QGraphicsLineItem *addedLine;
};
