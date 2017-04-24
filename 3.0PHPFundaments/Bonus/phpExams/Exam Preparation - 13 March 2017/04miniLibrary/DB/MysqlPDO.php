<?php

namespace DB;

class MysqlPDO extends PDO {
    private $connect = null;
    public function __construct($dsn,$dbusername,$dbpassword) { 
        parent::__construct($dsn, $dbusername, $dbpassword);
        $this->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
    }
    public function MSelectOnly($table, $select = ' * ', $where = null) {
        $sth = $this->prepare('SELECT '.$select.' FROM '.$table.'  '.$where);
        $sth->execute();
        // echo "<pre>";
        // print_r($sth);
        // echo "</pre>";
        return $sth->fetch(PDO::FETCH_BOTH);
    }
    public function MSelectList($table, $select = ' * ', $where = null) {
    	$sth = $this->prepare('SELECT '.$select.' FROM '.$table.'  '.$where);
        $sth->execute();
        // echo "<pre>";
        // print_r($sth);
        // echo "</pre>";
        return $sth->fetchAll(); 
    }
    private function Loops($result, $arr = null) { 
            while ($row = $result->fetch(PDO::FETCH_BOTH)):
                $arr[] = $row;
            endwhile; 
        return $arr;
    }
    public function MSelect($table, $select = ' * ', $where = null) {
        $sth = $this->prepare('SELECT '.$select.' FROM '.$table.'  '.$where);
        $sth->execute();  
    }
    public function MUpdate($table, $set, $where) {
        $query = 'UPDATE ' . $table . ' SET ' . $set . '  ' . $where;
        $sth = $this->prepare($query);
        // echo "<pre>";
        // print_r($sth);
        // echo "</pre>";
        $sth->execute();
    }
    public function MInsert($table, $set) {
        $query = 'INSERT INTO ' . $table . ' ' . $set;
        $sth = $this->prepare($query);
        // echo "<pre>";
        // print_r($sth);
        // echo "</pre>";
        $sth->execute();
    }

    public function MDelete($table, $where = null) {
        $query = 'DELETE FROM ' . $table . ' ' . $where;
        $sth = $this->prepare($query);
        // echo "<pre>";
        // print_r($sth);
        // echo "</pre>";
        $sth->execute();
    }
}