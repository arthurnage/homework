#include "deletecommand.h"

DeleteCommand::DeleteCommand(QGraphicsLineItem *newLine)
{
    deletedLine = newLine;
}

DeleteCommand::~DeleteCommand()
{
    delete deletedLine;
}

void DeleteCommand::act()
{
    deletedLine->setVisible(true);
    deletedLine->setFlag(QGraphicsItem::ItemIsSelectable, true);
}

void DeleteCommand::react()
{
    deletedLine->setVisible(false);
    deletedLine->setFlag(QGraphicsItem::ItemIsSelectable, false);
}
