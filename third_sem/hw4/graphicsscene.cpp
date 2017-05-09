#include "graphicsscene.h"
#include "addcommand.h"
#include "deletecommand.h"
#include "qmath.h"
#include <QDebug>
#include <QGraphicsEllipseItem>
#include <QGraphicsPathItem>
#include <QPainterPath>


GraphicsScene::GraphicsScene(QObject *parent) :
    QGraphicsScene(parent)
{
    this->setBackgroundBrush(Qt::gray);
}

void GraphicsScene::mouseReleaseEvent(QGraphicsSceneMouseEvent * mouseEvent)
{
    if (this->selectedItems().size() == 0)
    {
        return;
    }
    qDebug() << Q_FUNC_INFO << mouseEvent->scenePos();
    int radius = 14;
    auto list = this->selectedItems();
    QPointF *closestLinePoint = nullptr;
    QGraphicsLineItem *selectedLine = static_cast<QGraphicsLineItem*>(list.isEmpty() ? nullptr : list.first());
    QPointF p1 = selectedLine->mapToScene(selectedLine->line().p1());
    QPointF p2 = selectedLine->mapToScene(selectedLine->line().p2());
    auto x1 = p1.x();
    auto y1 = p1.y();
    auto x2 = p2.x();
    auto y2 = p2.y();
    if (closestPoint == nullptr)
    {
        qreal dist1 = qSqrt(qPow((x1 - mouseEvent->scenePos().x()), 2) + qPow((y1 - mouseEvent->scenePos().y()), 2));
        qreal dist2 = qSqrt(qPow((x2 - mouseEvent->scenePos().x()), 2) + qPow((y2 - mouseEvent->scenePos().y()), 2));
        qreal minDist = dist1 < dist2 ? dist1 : dist2;
        qreal closestLinePointX = dist1 < dist2 ? x1 : x2;
        qreal closestLinePointY = dist1 < dist2 ? y1 : y2;
        closestLinePoint = new QPointF(closestLinePointX, closestLinePointY);
        if (minDist < radius)
        {
            closestPoint = closestLinePoint;
            return;
        }
    }
    else if (closestPoint != nullptr)
    {
        QGraphicsLineItem *newLine = nullptr;
        if (x1 == closestPoint->x() && y1 == closestPoint->y())
        {
            newLine = this->addLine(mouseEvent->scenePos().x(), mouseEvent->scenePos().y(), x2, y2);
            newLine->setFlag(QGraphicsItem::ItemIsSelectable);
            undoPush(new AddCommand(newLine));
        }
        else
        {
            newLine = this->addLine(x1, y1, mouseEvent->scenePos().x(), mouseEvent->scenePos().y());
            newLine->setFlag(QGraphicsItem::ItemIsSelectable);
            undoPush(new AddCommand(newLine));
        }
        selectedLine->setFlag(QGraphicsItem::ItemIsSelectable, false);
        redoClear();
        undoPush(new DeleteCommand(selectedLine));
        selectedLine->setVisible(false);


        closestPoint = nullptr;
        return;
    }
    QGraphicsScene::mouseReleaseEvent(mouseEvent);
}

void GraphicsScene::undoPush(Command *command) {undoList.push_front(command);}

void GraphicsScene::redoPush(Command *command) {redoList.push_front(command);}

Command* GraphicsScene::undoPop()
{
    auto pop = undoList.front();
    undoList.pop_front();
    return pop;
}

Command* GraphicsScene::redoPop()
{
    auto pop = redoList.front();
    redoList.pop_front();
    return pop;
}

void GraphicsScene::redoClear() {redoList.clear();}

int GraphicsScene::redoSize() {return redoList.size();}

int GraphicsScene::undoSize() {return undoList.size();}

Command* GraphicsScene::undoTop() {return undoList.front();}

Command* GraphicsScene::redoTop() {return redoList.front();}

void GraphicsScene::undo()
{
    if (this->undoSize())
    {
        auto command = this->undoTop();
        this->undoPop();
        command->act();
        this->redoPush(command);
    }
}

void GraphicsScene::redo()
{
    if (redoSize())
    {
        auto command = redoTop();
        this->redoPop();
        command->react();
        this->undoPush(command);
    }
}
