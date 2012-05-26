<?php
/**
 * Created by PhpStorm.
 * User: Stefan
 * Date: 18.07.2010
 * Time: 14:55:36
 * To change this template use File | Settings | File Templates.
 */
 
class G3Client {
    const URL= "http://ws.audioscrobbler.com/2.0/";
    const POST_STRING = "method=%s&api_key=%s";
    const POST_USER = "&user=%s";
    private $apikey = "";
    private $secure = "";
    /**
     * @param  $key
     * @param  $secure
     * @return void
     */
    public function __construct($key, $secure){
        $this->setApikey($key);
        $this->secure = $secure;
    }
    public function getApikey(){
        return $this->apikey;
    }
    protected function setApikey($key){
        $this->apikey = $key;
    }
    private $user = "";
    public function setUser($user){
        $this->user = $user;
    }
    public function getUser(){
        return $this->user;
    }
    protected function getData($method, $withUser = false){
        $ch = curl_init(self::URL);
        curl_setopt($ch, CURLOPT_POST,1);
        if($this->apikey == ""){
            throw new Exception("apikey required! Please set apikey");
        }
        if($withUser){
            if($this->user == "") {
                throw new Exception("user required! Please set user");
            }
            curl_setopt($ch, CURLOPT_POSTFIELDS, sprintf(self::POST_STRING.self::POST_USER, $method, $this->getApikey(), urlencode($this->getUser())));
        } else {
            curl_setopt($ch, CURLOPT_POSTFIELDS, sprintf(self::POST_STRING, $method, $this->getApikey()));
        }
        curl_setopt($ch, CURLOPT_FOLLOWLOCATION,1);
        curl_setopt($ch, CURLOPT_HEADER ,0);  // DO NOT RETURN HTTP HEADERS
        curl_setopt($ch, CURLOPT_RETURNTRANSFER,1);  // RETURN THE CONTENTS OF THE CALL
        return curl_exec($ch);
    }
}
