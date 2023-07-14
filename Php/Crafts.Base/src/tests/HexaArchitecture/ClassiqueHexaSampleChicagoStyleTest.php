<?php declare(strict_types=1);

use PHPUnit\Framework\TestCase;

class ClassiqueHexaSampleChicagoStyleTest extends TestCase
{
    public function test_GivenAnExemplePortMethod_WhenICallHer_IGotAResponse()
    {
        $myRequest = new PrimaryPortRequestExemple();
        $givenExemplePort= new PrimaryAdapterExemple();
        $attempt=  $givenExemplePort->callMe($myRequest);
        
        
        $this->assertEquals($attempt->getIsOk(), (new PrimaryPortResponse(true))->getIsOk());
    }
}

class PrimaryAdapterExemple
{
    public function callMe(PrimaryPortRequestExemple $request) : PrimaryPortResponse
    {
        return new PrimaryPortResponse(true);
    }
    
}
class PrimaryPortRequestExemple
{}
class PrimaryPortResponse
{
    
    protected bool $isOk;

    public function __construct(bool $ok = false)
    {
        $this->isOk = $ok;
    }

    public function getIsOk(): bool
    {
        return $this->isOk;
    }
}