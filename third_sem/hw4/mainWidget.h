#pragma once

#include "graphicsscene.h"
#include <QtWidgets/QWidget>
#include <QtWidgets/QGraphicsView>
#include <QtWidgets>
#include <QPushButton>

class Widget : public QWidget
{
    Q_OBJECT

public:
    Widget(QWidget *parent = 0);
    ~Widget();

private:
    GraphicsScene mScene;
    QGraphicsView *mView;
    QList<Command*> undoList;
    QList<Command*> redoList;

private slots:
    void addLine();
    void deleteLine();
};

