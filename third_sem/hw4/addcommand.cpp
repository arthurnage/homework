#include "addcommand.h"

AddCommand::AddCommand(QGraphicsLineItem *newLine)
{
    addedLine = newLine;
}

AddCommand::~AddCommand()
{
    delete addedLine;
}

void AddCommand::act()
{
    addedLine->setVisible(false);
    addedLine->setFlag(QGraphicsItem::ItemIsSelectable, false);
}

void AddCommand::react()
{
    addedLine->setVisible(true);
    addedLine->setFlag(QGraphicsItem::ItemIsSelectable, true);
}
