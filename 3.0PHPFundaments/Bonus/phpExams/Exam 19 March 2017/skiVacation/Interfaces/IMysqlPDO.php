<?php

Interface IMysqlPDO {
    public function MSelectOnly($table, $select = ' * ', $where = null);

    public function MSelectList($table, $select = ' * ', $where = null);

    public function MSelect($table, $select = ' * ', $where = null);

    public function MUpdate($table, $set, $where);

    public function MInsert($table, $set);

    public function MDelete($table, $where = null);
}