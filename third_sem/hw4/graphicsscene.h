#pragma once

#include <QGraphicsScene>
#include <QGraphicsSceneMouseEvent>
#include <QPointF>
#include <QList>
#include "command.h"


class GraphicsScene : public QGraphicsScene
{
    Q_OBJECT
public:
    explicit GraphicsScene(QObject *parent = 0);
    void mouseReleaseEvent(QGraphicsSceneMouseEvent *mouseEvent);
    void undoPush(Command *command);
    void redoPush(Command *command);
    Command *undoPop();
    Command *redoPop();
    void redoClear();
    int redoSize();
    int undoSize();
    Command *undoTop();
    Command *redoTop();
public slots:
    void undo();
    void redo();
private:
    QPointF *closestPoint = nullptr;
    QList<Command*> undoList;
    QList<Command*> redoList;
};
