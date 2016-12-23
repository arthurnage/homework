#include "mainWidget.h"
#include "graphicsScene.h"
#include "addcommand.h"
#include "deletecommand.h"

#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QGraphicsRectItem>
#include <QtWidgets>
#include <QImage>
#include <QPainter>

Widget::Widget(QWidget *parent)
    : QWidget(parent)
{
    mView = new QGraphicsView(&mScene, this);
    mView->setSceneRect(0, 0, 300, 200);
    this->resize(300, 300);
    mScene.setBackgroundBrush(Qt::white);
    const auto layout = new QGridLayout(this);
    layout->addWidget(mView, 0, 0, 1, 4);

    const auto undoButton = new QPushButton("Undo");
    const auto redoButton = new QPushButton("Redo");
    const auto lineButton = new QPushButton("Line");
    const auto deleteButton = new QPushButton("Detele");

    layout->addWidget(redoButton, 1, 0);
    layout->addWidget(undoButton, 1, 1);
    layout->addWidget(lineButton, 1, 2);
    layout->addWidget(deleteButton, 1, 3);

    connect(lineButton, SIGNAL(clicked()), this, SLOT(addLine()));
    connect(deleteButton, SIGNAL(clicked()), this, SLOT(deleteLine()));
    connect(undoButton, SIGNAL(clicked()), &mScene, SLOT(undo()));
    connect(redoButton, SIGNAL(clicked()), &mScene, SLOT(redo()));

}

Widget::~Widget()
{

}

void Widget::deleteLine()
{
    auto list = mScene.selectedItems();
    if (list.size() == 0)
    {
        return;
    }
    QGraphicsLineItem *line = static_cast<QGraphicsLineItem*>(list.first());
    mScene.redoClear();
    mScene.undoPush(new DeleteCommand(line));
    line->setVisible(false);
}

void Widget::addLine()
{
    auto line = new QGraphicsLineItem();
    line->setLine(0, 0, 70, 70);
    mScene.addItem(line);
    line->setFlag(QGraphicsItem::ItemIsSelectable);
    mScene.redoClear();
    mScene.undoPush(new AddCommand(line));
}


