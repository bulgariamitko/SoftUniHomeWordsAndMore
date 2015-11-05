package game.enities;

import gfx.Assets;
import gfx.SpriteSheet;

import java.awt.*;

public class Player {
    private final int CHUCK_NORRIS = Integer.MAX_VALUE;
    private String name;
    private int width, height, x, y, velocityX, velocityY, health;
    public static boolean isMovingLeft;
    public static boolean isMovingRight;

    private SpriteSheet playerImage;
    private Rectangle boundingBox;

    private int col;

    public Player(String name, int width, int height, int x, int y) {
        this.name = name;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
        this.velocityX = this.velocityY = 4;
        this.health = CHUCK_NORRIS;

        this.boundingBox = new Rectangle(x, y, width, height);
        this.playerImage = new SpriteSheet(Assets.player, width, height);
        this.col = 0;
    }

    public void tick() {
        col++;
        if (col >= 7) {
            col = 0;
        }
        this.boundingBox.setBounds(this.x, this.y, this.width, this.height);
        if (isMovingRight) {
            this.x += this.velocityX;
        } else if (isMovingLeft) {
            this.x -= this.velocityX;
        }
    }

    public void render(Graphics g) {
        if (isMovingLeft) {
            g.drawImage(this.playerImage.crop(2, col), this.x, this.y, null);
        } else if (isMovingRight) {
            g.drawImage(this.playerImage.crop(3, col), this.x, this.y, null);
        } else {
            g.drawImage(this.playerImage.crop(0, 0), this.x, this.y, null);
        }

    }

    public boolean intersects (Rectangle enemy) {
        if (this.boundingBox.contains(enemy.x, enemy.y) || enemy.contains(this.boundingBox.x, this.boundingBox.y)) {
            return true;
        }
        return false;
    }
}
